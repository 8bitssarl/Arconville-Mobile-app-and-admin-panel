﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class newEditReservation : PageModel
    {
        private void GenerateDataModel(string userId, DatabaseHelper db)
        {
            List<Models.UserSubscription> subscriptions = new List<Models.UserSubscription>();
            List<Models.Reservation> reservations = new List<Models.Reservation>();
            List<Models.GenericModel> family = new List<Models.GenericModel>();
            List<Models.UserPayment> payments = new List<Models.UserPayment>();
            string query = $"select *from user where id={userId} ";
             
            //query=    "SELECT us.*,bs.name AS service_name FROM usersubscription us,bookingservice bs WHERE bs.id=us.service_id AND us.user_id=" + userId;
            //query += " UNION SELECT us.*,bs.title AS service_name FROM usersubscription us,package bs WHERE bs.id=us.package_id AND us.user_id=" + userId + " ORDER BY start_ts DESC";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                Models.GenericModel x = new Models.GenericModel();
                x.CreateFromReader(reader);
                ViewData["User"] = x;


            }
            reader.Close();
            comm.Dispose();
            query = $"select *from reservationtiming";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            List<Models.GenericModel> rsrTimingList = new List<Models.GenericModel>();
            while (reader.Read())
            {
                Models.GenericModel x = new Models.GenericModel();
                x.CreateFromReader(reader);
                rsrTimingList.Add(x);
            }

            reader.Close();
            comm.Dispose();
            ViewData["reservationtimings"] = rsrTimingList;
            //query = $"select u.id,u.name,u.profile_pic_url,u.email,u.phone_number, " +
            //       $"From_UnixTime( r.checkin_at)as checkIn,From_UnixTime( r.checkout_at) as checkOut," +
            //       $" r.is_cancel, From_UnixTime(r.start_ts)as startTime,From_UnixTime( r.reserve_ts) as reserveTime," +
            //       $"r.num_hours from user u INNER JOIN reservation r ON u.id=r.user_id where " +
            //       $" u.id = {userId}";
            //comm = db.Connection.CreateCommand();
            //comm.CommandText = query;
            //reader = comm.ExecuteReader();
            //List<Models.GenericModel> lst = new List<Models.GenericModel>();
            //while (reader.Read())
            //{
            //    Models.GenericModel x = new Models.GenericModel();
            //    x.CreateFromReader(reader);
            //    lst.Add(x);
            //}

            //reader.Close();
            //comm.Dispose();
            //ViewData["UserReservations"] = lst;

            query = "SELECT  u.name AS user_name,s.name AS service_name,From_UnixTime(r.reserve_ts) as ReserveDate, r.* FROM reservation r,bookingservice s,user u WHERE r.user_id=" + userId + " AND r.service_id=s.id AND r.user_id=u.id";
            query += " AND (r.reserve_ts>= UNIX_TIMESTAMP()) and r.checkout_at is null ORDER BY r.reserve_ts ASC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                long ts =0;
                if(reader["start_ts"]!=DBNull.Value)
                 ts = long.Parse(reader["start_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                //ts = long.Parse(reader["reserve_ts"].ToString());
                //dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                //string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
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
        
                    ReserveDate = reader["ReserveDate"].ToString(),
                    CheckinAt = reader["checkin_at"].ToString(),
                    CheckinAtDate = checkinStr,
                    CheckoutAt = reader["checkout_at"].ToString(),
                    CheckoutAtDate = checkoutStr
                };

                var y = Convert.ToDateTime(reader["ReserveDate"].ToString());
                x.StartDate =y.ToString() ;
                x.EndDate = y.AddHours(Convert.ToInt32(x.NumHours)).ToString();
                reservations.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Reservations"] = reservations;

        }

        public void OnGet()
        {
            try
            {
                string userId = Request.Query["user_id"];
                if (userId == null)
                {
                    userId = "1";
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(userId,db);
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

        public void OnPost()
        {
            try
            {
                string userId = Request.Query["user_id"];
                if (userId == null)
                {
                    userId = "1";
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(userId, db);
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}