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
                    var x = new
                    {
                        id = reader["id"].ToString(),
                        name = reader["name"].ToString(),
                        can_book_online = reader["can_book_online"].ToString(),
                        image_url = reader["image_url"].ToString(),
                    };
                    services.Add(x);
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

                query = "SELECT bs.name AS service_name,ps.* FROM packageservice ps,bookingservice bs WHERE bs.id=ps.service_id";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    var x = new
                    {
                        service_name = reader["service_name"].ToString(),
                        package_id = reader["package_id"].ToString(),
                        service_id = reader["service_id"].ToString(),
                    };
                    services.Add(x);
                }
                reader.Close();

                query = "SELECT p.title,p.amount,p.num_months AS orig_months,us.num_months,us.amount_paid,us.discount,us.start_ts,UNIX_TIMESTAMP(NOW()) curr_ts FROM package p,usersubscription us WHERE p.id=us.package_id AND us.user_id="+userId+" ORDER BY p.title";
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
    }
}
