using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace ZiadBooking.Pages
{
    public class ReservationModel : PageModel
    {
        
  

        private string GetProfilePicImageUrl()
        {
            var folderName = Path.Combine("wwwroot", "ProfileImages");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (Request.Form.Files == null || Request.Form.Files.Count == 0)
            {
                return "";
            }
            IFormFile file = Request.Form.Files[0];
            try
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    //var dbPath = Path.Combine(folderName, fileName);
                    var dbPath = Path.Combine("ProfileImages", fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string url = dbPath;
                    return url;
                }
            }
            catch (Exception ex)
            {
            }
            return "";
        }

        public void OnPost()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                
                string id = "0";
                string user_id = Request.Query["user_id"];
                id = Request.Query["id"];
                if (id == null)
                {
                    id = "0";
                }
                string packageId = Request.Form["package"];
                string date = Request.Form["date"];
                string time = Request.Form["time"];
                var currentDateTime = DateTime.Now;
                var month = currentDateTime.Month.ToString();
                if (month.Length < 2)
                {
                    month = "0" + month;
                }
                var year = currentDateTime.Year;
                var newDate = year + "-" + month + "-" + date;
                var newTime = "0" + time + ":00:00";
                //var dt = Convert.ToDateTime(newDate + " " + newTime);
                
               
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
               
            
                if (id.CompareTo("0") == 0)
                {
                    string query = $"insert into subscriptionrequest(user_id,package_id,request_dt) values('{user_id}','{packageId}','{newDate+" "+newTime}')";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                
                    comm.ExecuteNonQuery();
                }
                else
                {
                    string query = $"UPDATE  subscriptionrequest set package_id='{packageId}',request_dt='{newDate + " " + newTime}' where user_id='{user_id}' and id='{id}'";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
             
                    comm.ExecuteNonQuery();
                }
                db.Close();
                //Response.Redirect("BookingServices");
                Response.Redirect("Users");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
        private void GenerateDataModel(string userId,string Id, DatabaseHelper db)
        {
            List<Models.Reservation> reservations = new List<Models.Reservation>();
            string query = $"SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.Id={Id} r.service_id=s.id AND r.user_id=u.id";
            query += " AND UNIX_TIMESTAMP()<r.start_ts ORDER BY r.start_ts ASC";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
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
                try
                {
                    ts = long.Parse(reader["checkin_at"].ToString());
                    checkinStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                }
                catch { }
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
                    CheckoutAtDate = checkoutStr,
                    Latitude = reader["latitude"].ToString(),
                    Longitude = reader["longitude"].ToString(),
                };
                reservations.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Reservations"] = reservations;
        }

        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                string userId = Request.Query["user_id"];
                string reservationId = Request.Query["Id"];
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                //if(reservationId!=null && userId!=null)
                //GenerateDataModel(userId,reservationId, db);
                string query = "SELECT Id,title FROM package";
                MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                comm.CommandText = query;
                IDataReader reader = comm.ExecuteReader();
                List<object> lst = new List<object>();
                List<object> lstDays = new List<object>();
                List<object> lstHours = new List<object>();
                while (reader.Read())
                {
                    var x = new
                    {
                        Key = reader["Id"],
                        Value = reader["title"]
                    };
                    lst.Add(x);
                }

                reader.Close();
                db.Close();
                
                var day1 = new
                {
                    Key = DateTime.Now.AddDays(1).Day,
                    Value = DateTime.Now.AddDays(1).Day
                };
                var day2 = new
                {
                    Key = DateTime.Now.AddDays(1).Day,
                    Value = DateTime.Now.AddDays(2).Day
                };

                lstDays.Add(day1);
                lstDays.Add(day2);
             
                var hour1 = new
                {
                    Key = 8,
                    Value = "08:00 duration 2 hours"
              
                };
                var hour2 = new
                {
                    Key = 10,
                    Value =
              "10:00 duration 2 hours"
           
                };
                var hour3 = new
                {
                    Key = 12,
                    Value =
           
              "12:00 duration 2 hours"
              
                };
                var hour4 = new
                {
                    Key = 14,
                    Value =
           
              
              "14:00 duration 2 hours"
             
                };
                var hour5 = new
                {
                    Key = 16,
                    Value =


            
              "16:00 duration 2 hours"
              
                };
                var hour6 = new
                {
                    Key = 18,
                    Value =



             
              "18:00 duration 2 hours"
                };
                lstHours.Add(hour1);
                lstHours.Add(hour2);
                lstHours.Add(hour3);
                lstHours.Add(hour4);
                lstHours.Add(hour5);
                lstHours.Add(hour6);

                ViewData["packages"] = lst;
                ViewData["days"] = lstDays;
                ViewData["hours"] = lstHours;
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

    }
}