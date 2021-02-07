using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Pages
{
    public class ReservationsModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            List<Models.Reservation> reservations = new List<Models.Reservation>();
            string query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.service_id=s.id AND r.user_id=u.id";
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
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(userId,db);
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}