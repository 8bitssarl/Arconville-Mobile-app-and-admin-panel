using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;

namespace ZiadBooking.Pages
{
    public class ReceptionModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            List<Models.UserSubscription> subscriptions = new List<Models.UserSubscription>();
            List<Models.Reservation> reservations = new List<Models.Reservation>();
            List<Models.GenericModel> family = new List<Models.GenericModel>();
            string query = "SELECT us.*,bs.name AS service_name FROM usersubscription us,bookingservice bs WHERE bs.id=us.service_id AND us.user_id=" + userId + " ORDER BY start_ts DESC";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                long ts = long.Parse(reader["start_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDate(dt);
                int numMonths = int.Parse(reader["num_months"].ToString());
                DateTime dtExp = new DateTime(dt.Ticks);
                dtExp=dtExp.AddMonths(numMonths);
                string expStr = Models.Helper.GetDatabaseDate(dtExp);
                long expTs = Models.Helper.UnixTimestampFromDateTime(dtExp);
                if (expTs < Models.Helper.UnixTimestampFromDateTime(DateTime.Now))
                {
                    expStr += " (EXPIRED)";
                }
                else
                {
                    expStr += " (ACTIVE)";
                }
                Models.UserSubscription x = new Models.UserSubscription()
                {
                    Id = reader["id"].ToString(),
                    UserId = reader["user_id"].ToString(),
                    ServiceId = reader["service_id"].ToString(),
                    StartTs = reader["start_ts"].ToString(),
                    NumMonths = reader["num_months"].ToString(),
                    AmountPaid = reader["amount_paid"].ToString(),
                    Details = reader["details"].ToString(),
                    ServiceName = reader["service_name"].ToString(),
                    StartDate = dateStr,
                    ExpiredAt = expStr,
                };
                subscriptions.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Subscriptions"] = subscriptions;

            query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.user_id="+userId+" AND r.service_id=s.id AND r.user_id=u.id";
            query += " AND (UNIX_TIMESTAMP()<r.start_ts OR (r.checkin_at IS NOT NULL AND r.checkout_at IS NULL)) ORDER BY r.start_ts ASC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                long ts = long.Parse(reader["start_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                ts = long.Parse(reader["reserve_ts"].ToString());
                dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
                string checkinStr = "";
                string checkoutStr = "";
                try {
                    ts = long.Parse(reader["checkin_at"].ToString());
                    checkinStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                } catch { }
                try
                {
                    ts = long.Parse(reader["checkout_at"].ToString());
                    checkoutStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                }
                catch { }
                Models.Reservation x = new Models.Reservation()
                {
                    Id = reader["id"].ToString(),
                    UserName = reader["user_name"].ToString(),
                    ServiceName = reader["service_name"].ToString(),
                    NumHours = reader["num_hours"].ToString(),
                    StartDate = dateStr,
                    EndDate = endStr,
                    ReserveDate = reserveStr,
                    CheckinAt = reader["checkin_at"].ToString(),
                    CheckinAtDate = checkinStr,
                    CheckoutAt = reader["checkout_at"].ToString(),
                    CheckoutAtDate = checkoutStr
                };
                reservations.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Reservations"] = reservations;

            query = "SELECT u.name,u.email,u.phone_number,f.relation FROM family f,user u WHERE f.user_id=" + userId + " AND f.child_id=u.id";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.GenericModel x = new Models.GenericModel();
                x.CreateFromReader(reader);
                family.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Family"] = family;
        }

        public void OnPost()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                string name = Request.Form["name"];
                ViewData["UserName"]=name;
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                string userId = "0";
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = $"SELECT (select Count(s.user_id) from usersubscription s where s.user_id=u.Id "+
       $" and Now() < DATE_ADD(Date(From_UnixTime(s.start_ts)), INTERVAL s.num_months Month) "+
      $" ) as subscription, u.* FROM `user` u where LOWER(name) like '%{name}%' or email like '%{name}%'  ORDER BY name ";
                comm.Parameters.AddWithValue("@name", name.ToLower());
                IDataReader reader = comm.ExecuteReader();
                List<Models.User> usrList = new List<Models.User>();
                while (reader.Read())
                {

                    Models.User usr = new Models.User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        ProfilePicUrl = reader["profile_pic_url"].ToString(),
                        subscription= Convert.ToInt32( reader["subscription"].ToString()),
                        isSuspended = Convert.ToBoolean(reader["isSuspended"]),
                    };
                    if(usr.subscription>0 && usr.isSuspended == false)
                    {
                        usr.isActive = true;

                    }else if (usr.isSuspended == true)
                    {
                        usr.isActive = false;
                    }else
                        if (usr.subscription == 0)
                    {
                       usr.isActive= false;
                    }
                    usrList.Add(usr);
              
                    
                }
                ViewData["Users"] = usrList;
                
                //else
                //{
                //    reader.Close();
                //    //ViewData["Message"] = "User not found with the name "+name;
                //    comm = (MySqlCommand)db.Connection.CreateCommand();
                //    comm.CommandText = "SELECT * FROM user WHERE LOWER(email)=@name";
                //    comm.Parameters.AddWithValue("@name", name.ToLower());
                //    reader = comm.ExecuteReader();
                //    if (reader.Read())
                //    {
                //        Models.User usr = new Models.User()
                //        {
                //            Id = reader["id"].ToString(),
                //            Name = reader["name"].ToString(),
                //            Email = reader["email"].ToString(),
                //            PhoneNumber = reader["phone_number"].ToString(),
                //            ProfilePicUrl = reader["profile_pic_url"].ToString(),
                //        };
                //        ViewData["User"] = usr;
                //        userId = usr.Id;
                //    }
                //    else
                //    {
                //        ViewData["Message"] = "User not found with the name or email: " + name;
                //    }
                //}
                reader.Close();
                userId = usrList.FirstOrDefault().Id;
                if (userId.CompareTo("0") != 0)
                {
                    var statusRequest = Request.Form["status"];
                    if (!string.IsNullOrEmpty(statusRequest))
                    {
                        string status = Request.Form["status"];
                        
                        string reservationId = Request.Form["reservation_id"];
                        comm = (MySqlCommand)db.Connection.CreateCommand();
                        string nowTs = Models.Helper.UnixTimestampFromDateTime(DateTime.Now).ToString();
                        if (status.CompareTo("checkin") == 0)
                        {
                            if (!string.IsNullOrEmpty(reservationId))
                            {

                            }

                            string q1 = $"UPDATE reservation SET checkin_at= '{nowTs}' WHERE Date(From_UnixTime(reserve_ts)) = Date(From_UnixTime('{nowTs}')) and user_id={userId} and checkout_at is null";
                                
                          
                            comm.CommandText = q1;

                            int count = comm.ExecuteNonQuery();
                            if (count == 0)
                            {
                                comm.CommandText = $"INSERT INTO `reservation`(`user_id`, `service_id`,  `reserve_ts`, `start_ts`, `checkin_at`,`num_hours`) VALUES ({userId},0,'{nowTs}','{nowTs}','{nowTs}',2)";
                                comm.ExecuteNonQuery();
                            }
                        }
                        else if (status.CompareTo("checkout") == 0)
                        {
                            
                          string q2   = $"UPDATE reservation SET checkout_at= '{nowTs}' WHERE Date(From_UnixTime(reserve_ts)) <= Date(From_UnixTime('{nowTs}')) and user_id={userId} and checkout_at is null";
                            
                            comm.CommandText = q2;
                            int count=  comm.ExecuteNonQuery();
                        }
                        
                    }
                    GenerateDataModel(userId, db);
                }
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                //string userId = Request.Query["user_id"];
                //DatabaseHelper db = new DatabaseHelper();
                //db.Open();
                //GenerateDataModel(userId,db);
                //db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}