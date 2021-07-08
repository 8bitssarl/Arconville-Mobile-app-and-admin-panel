using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Pages
{
    public class SubscriptionModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            List<Models.BookingService> services = new List<Models.BookingService>();
            List<Models.BookingPackage> packages = new List<Models.BookingPackage>();
            List<Models.UserSubscription> subscriptions = new List<Models.UserSubscription>();
            List<Models.UserPayment> payments = new List<Models.UserPayment>();
            string query = "SELECT * FROM bookingservice ORDER BY name";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.BookingService x = new Models.BookingService()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString()
                };
                services.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Services"] = services;

            query = "SELECT * FROM package ORDER BY title";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.BookingPackage x = new Models.BookingPackage()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["title"].ToString(),
                    ServiceId = reader["service_id"].ToString(),
                    NumMonths = reader["num_months"].ToString(),
                    Amount = reader["amount"].ToString(),
                };
                packages.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Packages"] = packages;

            //query = "SELECT us.*,bs.id AS service_id,'0' AS package_id,bs.name AS service_name FROM usersubscription us,bookingservice bs WHERE bs.id=us.service_id AND us.user_id=" + userId + " ORDER BY start_ts DESC";
            //comm = db.Connection.CreateCommand();
            //comm.CommandText = query;
            //reader = comm.ExecuteReader();
            //while (reader.Read())
            //{
            //    long ts = long.Parse(reader["start_ts"].ToString());
            //    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
            //    string dateStr = Models.Helper.GetDatabaseDate(dt);
            //    int numMonths = int.Parse(reader["num_months"].ToString());
            //    DateTime dtExp = new DateTime(dt.Ticks);
            //    dtExp=dtExp.AddMonths(numMonths);
            //    string expStr = Models.Helper.GetDatabaseDate(dtExp);
            //    long expTs = Models.Helper.UnixTimestampFromDateTime(dtExp);
            //    if (expTs < Models.Helper.UnixTimestampFromDateTime(DateTime.Now))
            //    {
            //        expStr += " (EXPIRED)";
            //    }
            //    else
            //    {
            //        expStr += " (ACTIVE)";
            //    }
            //    Models.UserSubscription x = new Models.UserSubscription()
            //    {
            //        Id = reader["id"].ToString(),
            //        UserId = reader["user_id"].ToString(),
            //        ServiceId = reader["service_id"].ToString(),
            //        StartTs = reader["start_ts"].ToString(),
            //        NumMonths = reader["num_months"].ToString(),
            //        AmountPaid = reader["amount_paid"].ToString(),
            //        Details = reader["details"].ToString(),
            //        ServiceName = reader["service_name"].ToString(),
            //        StartDate = dateStr,
            //        ExpiredAt = expStr,
            //    };
            //    subscriptions.Add(x);
            //}
            //reader.Close();
            //comm.Dispose();
            //ViewData["Subscriptions"] = subscriptions;

            query = "SELECT us.*,bs.name AS service_name FROM usersubscription us,bookingservice bs WHERE bs.id=us.service_id AND us.user_id=" + userId;
            query+= " UNION SELECT us.*,bs.title AS service_name FROM usersubscription us,package bs WHERE bs.id=us.package_id AND us.user_id=" + userId + " ORDER BY start_ts DESC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                long ts = long.Parse(reader["start_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDate(dt);
                int numMonths = int.Parse(reader["num_months"].ToString());
                DateTime dtExp = new DateTime(dt.Ticks);
                dtExp = dtExp.AddMonths(numMonths);
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
                    PackageId = reader["package_id"].ToString(),
                    StartTs = reader["start_ts"].ToString(),
                    NumMonths = reader["num_months"].ToString(),
                    AmountPaid = reader["amount_paid"].ToString(),
                    Discount = reader["discount"].ToString(),
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

            query = "SELECT up.*,bs.name AS service_name FROM userpayment up,bookingservice bs WHERE bs.id=up.service_id AND user_id=" + userId;
            query += " UNION SELECT up.*,bs.title AS service_name FROM userpayment up,package bs WHERE bs.id=up.package_id AND user_id=" + userId + " ORDER BY payment_ts DESC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                long ts = long.Parse(reader["payment_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDate(dt);

                Models.UserPayment x = new Models.UserPayment()
                {
                    Id = reader["id"].ToString(),
                    UserId = reader["user_id"].ToString(),
                    ServiceId = reader["service_id"].ToString(),
                    PaymentTs = reader["payment_ts"].ToString(),
                    PaymentDetails = reader["payment_details"].ToString(),
                    AmountPaid = reader["amount_paid"].ToString(),
                    Discount = reader["discount"].ToString(),
                    ServiceName = reader["service_name"].ToString(),
                    PackageId = reader["package_id"].ToString(),
                    PaymentDate = dateStr,
                };
                payments.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Payments"] = payments;
        }

        public void OnPost()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                string userId = Request.Query["user_id"];
                int serviceCount = int.Parse(Request.Form["service_count"]);
                string updateAll = Request.Form["update_all"];
                if (updateAll == null)
                {
                    updateAll = "0";
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                for (int a = 0; a < serviceCount; a++)
                {
                    string serviceId = Request.Form["service[" + a.ToString() + "][id]"];
                    string packageId = Request.Form["package[" + a.ToString() + "][id]"];
                    string numMonths = Request.Form["service[" + a.ToString() + "][num_months]"];
                    string amount = Request.Form["service[" + a.ToString() + "][amount]"];
                    string startDt = Request.Form["service[" + a.ToString() + "][start_dt]"];
                    string details = Request.Form["service[" + a.ToString() + "][details]"];
                    string update = Request.Form["service[" + a.ToString() + "][update]"];
                    string discount = Request.Form["service[" + a.ToString() + "][discount]"];
                    if (updateAll.CompareTo("0")==0 && update == null)
                    {
                        continue;
                    }

                    if (startDt.Trim().CompareTo("") == 0)
                    {
                        continue;
                    }

                    DateTime dt = Models.Helper.GetFromDatabaseDateTime(startDt);
                    long startTs = Models.Helper.UnixTimestampFromDateTime(dt);

                    string query = "SELECT * FROM usersubscription WHERE user_id=" + userId;
                    if (serviceId.CompareTo("0") != 0)
                    {
                        query += " AND service_id=" + serviceId;
                    }
                    else
                    {
                        query += " AND package_id=" + packageId;
                    }
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    MySqlCommand comm2 = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm2.CommandText = "update user set isActive=1 where Id=" + userId;
                    comm2.ExecuteNonQuery();
                    IDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        reader.Close();

                        //update
                        query = "UPDATE usersubscription SET";
                        query += " start_ts=@startTs,num_months=@numMonths,amount_paid=@amount,discount=@discount,details=@details";
                        query += " WHERE id=@id";

                        comm = (MySqlCommand)db.Connection.CreateCommand();
                        comm.CommandText = query;
                        comm.Parameters.AddWithValue("@startTs", startTs);
                        comm.Parameters.AddWithValue("@numMonths", numMonths);
                        comm.Parameters.AddWithValue("@amount", amount);
                        comm.Parameters.AddWithValue("@discount", discount);
                        comm.Parameters.AddWithValue("@details", details);
                        comm.Parameters.AddWithValue("@id", id);
                        comm.ExecuteNonQuery();
                        comm.Dispose();
                    }
                    else
                    {
                        reader.Close();
                        //insert
                        query = "INSERT INTO usersubscription(user_id,service_id,package_id,start_ts,num_months,amount_paid,discount,details)";
                        query += " VALUES(@userId,@serviceId,@packageId,@startTs,@numMonths,@amount,@discount,@details)";

                        comm = (MySqlCommand)db.Connection.CreateCommand();
                        comm.CommandText = query;
                        comm.Parameters.AddWithValue("@userId", userId);
                        comm.Parameters.AddWithValue("@serviceId", serviceId);
                        comm.Parameters.AddWithValue("@packageId", packageId);
                        comm.Parameters.AddWithValue("@startTs", startTs);
                        comm.Parameters.AddWithValue("@numMonths", numMonths);
                        comm.Parameters.AddWithValue("@amount", amount);
                        comm.Parameters.AddWithValue("@discount", discount);
                        comm.Parameters.AddWithValue("@details", details);
                        comm.ExecuteNonQuery();
                        comm.Dispose();
                    }

                    long paymentTs = Models.Helper.UnixTimestampFromDateTime(DateTime.Now);

                    //insert
                    query = "INSERT INTO userpayment(user_id,service_id,package_id,payment_ts,amount_paid,discount,payment_details)";
                    query += " VALUES(@userId,@serviceId,@packageId,@paymentTs,@amount,@discount,@details)";

                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@userId", userId);
                    comm.Parameters.AddWithValue("@serviceId", serviceId);
                    comm.Parameters.AddWithValue("@packageId", packageId);
                    comm.Parameters.AddWithValue("@paymentTs", paymentTs);
                    comm.Parameters.AddWithValue("@amount", amount);
                    comm.Parameters.AddWithValue("@discount", discount);
                    comm.Parameters.AddWithValue("@details", details);
                    comm.ExecuteNonQuery();
                    comm.Dispose();

                }

                GenerateDataModel(userId, db);
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
                string userId = Request.Query["user_id"];
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
               
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = "SELECT * FROM user WHERE id=@id";
                comm.Parameters.AddWithValue("@id",userId);
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    Models.User usr = new Models.User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString()
                    };
                    ViewData["User"] = usr;
                    userId = usr.Id;
                }
                else
                {
                    ViewData["Message"] = "User not found";
                }
                reader.Close();
                GenerateDataModel(userId, db);
                db.Close();

            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}