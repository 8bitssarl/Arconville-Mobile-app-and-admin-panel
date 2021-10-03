using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZiadBooking.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Controllers.api
{
    public class ReservationController : ZiadBookingApiController
    {
        [HttpGet]
        public ApiResponseModel Get()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                string query = "SELECT * FROM bookingservice ORDER BY name";
                System.Data.IDbCommand comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                List<dynamic> services = new List<dynamic>();
                System.Data.IDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dt = new DateTime();
                    var x = new
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        can_book_online = reader["can_book_online"].ToString(),
                        image_url = reader["image_url"].ToString(),
                        isSuspended= Convert.ToBoolean(reader["isSuspended"]),
                        rHours = reader["rHours"].ToString(),
                        suspentionDate = reader["suspentionDate"].ToString(),
                        isSubscribedOnline = Convert.ToBoolean(reader["isSubscribedOnline"]),
                    };
                    if (!string.IsNullOrEmpty(x.suspentionDate))
                    {
                         dt = Convert.ToDateTime(x.suspentionDate);
                        if(x.isSuspended.Equals(false) && dt >= DateTime.Now && x.isSubscribedOnline.Equals(false))
                        {
                            services.Add(x);
                        }
                    }
                    else
                    {
                        if(x.isSubscribedOnline.Equals(false))
                        services.Add(x);
                    }

                    
                }
                reader.Close();
                db.Close();
                return CreateApiResponseModel(200, "", services);
            }
            catch(Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        private bool CanUserReserveService(string userId,string serviceId,DatabaseHelper db)
        {
            string query = "SELECT us.id FROM usersubscription us";
            query += " WHERE UNIX_TIMESTAMP(DATE(NOW()))<(us.start_ts + (60 * 60 * 24 * 30 * us.num_months))";
            query += " AND us.user_id=" + userId + " AND us.service_id=" + serviceId;
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader=comm.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                comm.Dispose();
                return true;
            }
            reader.Close();
            comm.Dispose();

            query = "SELECT us.id FROM usersubscription us,packageservice ps";
            query += " WHERE UNIX_TIMESTAMP(DATE(NOW()))<(us.start_ts + (60 * 60 * 24 * 30 * us.num_months))";
            query += " AND us.user_id=" + userId + " AND ps.service_id=" + serviceId+" AND ps.package_id=us.package_id";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                comm.Dispose();
                return true;
            }
            reader.Close();
            comm.Dispose();

            return false;
        }

        [HttpPut]
        public ApiResponseModel Put()
        {
            try
            {
                string userId = Request.Form["user_id"];
                string reservationId = Request.Form["reservation_id"];
                int reservationCount = int.Parse(Request.Form["reservation_count"]);
                string latitude = Request.Form["latitude"];
                string longitude = Request.Form["longitude"];

                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                string reserveTs = Helper.UnixTimestampFromDateTime(DateTime.Now).ToString();

                for (int a = 0; a < reservationCount; a++)
                {
                    string rId = Request.Form["reservation[" + a.ToString() + "][id]"];
                    string serviceId = Request.Form["reservation[" + a.ToString() + "][service_id]"];
                    string startTs = Request.Form["reservation[" + a.ToString() + "][start_ts]"];
                    string numHours = Request.Form["reservation[" + a.ToString() + "][num_hours]"];

                    //check if they can reserve a service
                    if (!CanUserReserveService(userId, serviceId, db))
                    {
                        return CreateApiResponseModel(500,"You do not have any active subscription for this service", null);
                    }

                    Models.Reservation reservation = new Models.Reservation();
                    reservation.Id = rId;
                    reservation.UserId = userId;
                    reservation.ServiceId = serviceId;
                    reservation.NumHours = numHours;
                    reservation.ReserveTs = reserveTs;
                    reservation.StartTs = startTs;
                    reservation.Latitude = latitude;
                    reservation.Longitude = longitude;
                    if (rId.CompareTo("0") == 0)
                    {
                        reservation.Insert(db.Connection);
                    }
                    else
                    {
                        reservation.Update(db.Connection);
                    }
                }

                db.Close();

                return CreateApiResponseModel(200, "", null);
            }
            catch(Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpPost]
        [Route("cancel")]
        public ApiResponseModel Cancel()
        {
            string userId = Request.Form["user_id"];
            string reservationId = Request.Form["reservation_id"];
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = "UPDATE reservation SET is_cancel=1,cancel_at=UNIX_TIMESTAMP(NOW()) WHERE user_id=@userId AND id=@reservationId";
                comm.Parameters.AddWithValue("@userId", userId);
                comm.Parameters.AddWithValue("@reservationId", reservationId);
                comm.ExecuteNonQuery();
                db.Close();
                var x = new
                {
                    id = reservationId,
                };
                return CreateApiResponseModel(200, "", x);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }

        [HttpGet]
        [Route("packages")]
        public ApiResponseModel Packages()
        {
            string userId = Request.Query["user_id"];
            if (userId == null)
            {
                userId = "0";
            }
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                string query = "SELECT p.*,(SELECT COUNT(*) FROM subscriptionrequest sr WHERE sr.package_id=p.id AND sr.user_id="+userId+") AS sub_count FROM package p ORDER BY title";
                System.Data.IDbCommand comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                List<dynamic> upcoming = new List<dynamic>();
                List<dynamic> previous = new List<dynamic>();
                List<dynamic> services = new List<dynamic>();
                System.Data.IDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int subCount = int.Parse(reader["sub_count"].ToString());

                    var x = new
                    {
                        id = reader["id"].ToString(),
                        title = reader["title"].ToString(),
                        num_months = reader["num_months"].ToString(),
                        amount = reader["amount"].ToString(),
                        featured = reader["is_featured"].ToString(),
                        location_text = reader["location_text"].ToString(),
                        latitude = reader["latitude"].ToString(),
                        longitude = reader["longitude"].ToString(),
                        image_url = reader["image_url"].ToString(),
                        has_sub_request = subCount>0,
                    };
                    upcoming.Add(x);
                }
                reader.Close();

                query = "SELECT bs.name AS service_name,bs.rHours,bs.isSuspended,bs.suspentionDate, ps.* FROM packageservice ps,bookingservice bs WHERE bs.id=ps.service_id and isSubscribedOnline=1";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dt = new DateTime();
                    var x = new
                    {
                        service_name = reader["service_name"].ToString(),
                        package_id = reader["package_id"].ToString(),
                        service_id = reader["service_id"].ToString(),
                        isSuspended = Convert.ToBoolean(reader["isSuspended"]),
                        rHours = reader["rHours"].ToString(),
                        suspentionDate = reader["suspentionDate"].ToString(),
                    };
                    if (!string.IsNullOrEmpty(x.suspentionDate))
                    {
                        dt = Convert.ToDateTime(x.suspentionDate);
                        if (x.isSuspended.Equals(false) && dt >= DateTime.Now)
                        {
                            services.Add(x);
                        }
                    }
                    else
                    {
                        services.Add(x);
                    }
                }
                reader.Close();
                //: can book online, can subscribe online point no 11
                query = "SELECT p.title,p.amount,p.num_months AS orig_months,us.num_months,us.amount_paid,us.discount,us.start_ts,UNIX_TIMESTAMP(NOW()) curr_ts FROM package p,usersubscription us WHERE p.id=us.package_id AND us.user_id="+userId+ " and p.isSubcribedOnline=1 ORDER BY p.title";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    long ts = long.Parse(reader["start_ts"].ToString());
                    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    int numMonths = int.Parse(reader["num_months"].ToString());
                    DateTime dtExp = new DateTime(dt.Ticks);
                    dtExp = dtExp.AddMonths(numMonths);
                    string expStr = Models.Helper.GetDatabaseDate(dtExp);
                    long expTs = Models.Helper.UnixTimestampFromDateTime(dtExp);
                    if (expTs < Models.Helper.UnixTimestampFromDateTime(DateTime.Now))
                    {
                        continue;
                    }
                    var x = new
                    {
                        //id = reader["id"].ToString(),
                        title = reader["title"].ToString(),
                        amount = reader["amount"].ToString(),
                        amount_paid = reader["amount_paid"].ToString(),
                        orig_months = reader["orig_months"].ToString(),
                        num_months = reader["num_months"].ToString(),
                        discount = reader["discount"].ToString(),
                        start_ts = reader["start_ts"].ToString(),
                        exp_ts = expTs.ToString(),
                    };
                    previous.Add(x);
                }
                reader.Close();

                db.Close();
                var x2 = new
                {
                    upcoming = upcoming,
                    previous = previous,
                    services = services,
                };
                return CreateApiResponseModel(200, "", x2);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
        [HttpGet]
        [Route("UserSelectedPackages")]
        public IActionResult UserSelectedPackages()
        {
            string userId = Request.Query["user_id"];
            if (userId == null)
            {
                userId = "0";
            }
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
         
                
             
                List<dynamic> services = new List<dynamic>();
                
              
                

              string  query = $"select DISTINCT bs.name as service_name, bs.id as service_id  from usersubscription us " +
                    $" INNER JOIN packageservice ps ON ps.package_id= us.package_id  " +
                    $"INNER JOIN bookingservice bs ON ps.service_id = bs.id  " +
                    $" where Now() < DATE_ADD(Date(From_UnixTime(us.start_ts)), INTERVAL us.num_months Month) and bs.isSuspended=0   and us.user_id={userId} ";
                System.Data.IDbCommand comm = db.Connection.CreateCommand();

                comm.CommandText = query;
                System.Data.IDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    //DateTime dt = new DateTime();
                    var x = new
                    {
                        service_name = reader["service_name"].ToString(),
                        //package_id = reader["package_id"].ToString(),
                        service_id = reader["service_id"].ToString(),
                        //isSuspended = Convert.ToBoolean(reader["isSuspended"]),
                        //rHours = reader["rHours"].ToString(),
                        //suspentionDate = reader["suspentionDate"].ToString(),
                    };
                    services.Add(x);
                }
                reader.Close();
                //: can book online, can subscribe online point no 11
             
                return Ok(services);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [Route("subscribepackage")]
        public ApiResponseModel SubscribePackage()
        {
            string userId = Request.Form["user_id"];
            string packageId = Request.Form["package_id"];
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();

                comm.CommandText = "SELECT * FROM subscriptionrequest WHERE user_id=@userId AND package_id=@packageId";
                comm.Parameters.AddWithValue("@userId", userId);
                comm.Parameters.AddWithValue("@packageId", packageId);

                bool hasSub = false;
                IDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    hasSub = true;
                }
                reader.Close();

                comm = (MySqlCommand)db.Connection.CreateCommand();
                if (hasSub)
                {
                    comm.CommandText = "DELETE FROM subscriptionrequest WHERE user_id=@userId AND package_id=@packageId";
                }
                else
                {
                    comm.CommandText = "INSERT INTO subscriptionrequest(user_id,package_id,request_dt) VALUES(@userId,@packageId,NOW())";
                }
                comm.Parameters.AddWithValue("@userId", userId);
                comm.Parameters.AddWithValue("@packageId", packageId);
                comm.ExecuteNonQuery();
                db.Close();
                hasSub = !hasSub;
                var x = new
                {
                    has_sub_request = hasSub,
                };
                return CreateApiResponseModel(200, "",x);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
        [HttpPost]
        [Route("UserReservations")]
        public IActionResult UserReservations()
        {
            string userId = Request.Form["user_id"];
            string sService = Request.Form["sService"];
            string rDate = Request.Form["rDate"];
            try
            {
                //string reserveTs = Helper.UnixTimestampFromDateTime(Convert.ToDateTime(rDate)).ToString();
                List<GenericModel> lst = new List<GenericModel>();
                DatabaseHelper db = new DatabaseHelper();
                db.Open();

                    string query = $"SELECT `id`, `fk_reservationtimeId`, `fk_reservationId`, `fk_userId`, " +
                    $"`description`, `fk_subscription`,From_UnixTime( `reserve_ts`) FROM `selected_reservationtiming`  " +
                    $" where `fk_reservationId`='{sService}' and Date(From_UnixTime( `reserve_ts`)) = Date( '{rDate}') ";
                
                 
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = query;
                System.Data.IDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Models.GenericModel x = new Models.GenericModel();
                    x.CreateFromReader(reader);
                    lst.Add(x);
                }
                comm.Dispose();
                reader.Dispose();
                

                db.Close();


                return Ok(lst);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetById")]
        public ApiResponseModel GetById()
        {
            try
            {
                string rsr_Id = Request.Query["rsr_id"];

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                var id = (string)rsr_Id.ToString().Split('_')[1];
                string query = $"SELECT `id`, `user_id`, `service_id`, `num_hours`, `latitude`, `longitude`," +
                    $" Date(From_UnixTime( `reserve_ts`)) as reserve_ts, `start_ts`, `checkin_at`, `checkout_at`, `is_cancel`, `cancel_at` FROM `reservation` where id={id}";
                System.Data.IDbCommand comm = db.Connection.CreateCommand();
                comm.CommandText = query;

                System.Data.IDataReader reader = comm.ExecuteReader();
                Models.GenericModel x = new Models.GenericModel();
                if (rsr_Id.Contains("ed"))
                {
                    
                    if (reader.Read())
                    {


                        x.CreateFromReader(reader);



                    }
                    reader.Close();
                    
                    return CreateApiResponseModel(200, "", x);
                } else if (rsr_Id.Contains("dl"))
                {

                    query = $"Delete From selected_reservationtiming where reserve_ts=(Select reserve_ts from reservation where id='{id}' Limit 1); Delete from reservation where id='{id}'";
                    comm = db.Connection.CreateCommand();
                  int count =  comm.ExecuteNonQuery();
                    return CreateApiResponseModel(200, "Delete Record Sucessfully..", null);
                }
                db.Close();
                return CreateApiResponseModel(200, "Unknown", null);
            }
            catch (Exception ex)
            {
                return CreateApiResponseModel(500, "Exception: " + ex.Message, null);
            }
        }
        [HttpPost]
        [Route("FamilyAllCheckInOut")]
        public IActionResult FamilyAllCheckInOut()
        {
            string userId = Request.Query["user_id"];

            
            try
            {
                //string reserveTs = Helper.UnixTimestampFromDateTime(Convert.ToDateTime(rDate)).ToString();
                
                DatabaseHelper db = new DatabaseHelper();
                string nowTs = Models.Helper.UnixTimestampFromDateTime(DateTime.Now).ToString();
                db.Open();

                string query = $"INSERT INTO `reservation`( `user_id`, `service_id`, `num_hours`,  `reserve_ts`, `start_ts`, `checkin_at`)" +
                 $" SELECT u.id,'0','2','{nowTs}','{nowTs}','{nowTs}' FROM family f,user u WHERE f.user_id={userId} AND f.child_id=u.id;" +
                 $" INSERT INTO `reservation`( `user_id`, `service_id`, `num_hours`,  `reserve_ts`, `start_ts`, `checkin_at`)" +
                 $"  Values( {userId},'0','2','{nowTs}','{nowTs}','{nowTs}');";
                   
                System.Data.IDbCommand comm = db.Connection.CreateCommand();
                
                comm.CommandText = query;
                    

                    comm.CommandText = query;
                    comm.ExecuteNonQuery();
                
               
                
               
                comm.Dispose();
                


                db.Close();


                return Ok("Record save sucessfully...");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}
