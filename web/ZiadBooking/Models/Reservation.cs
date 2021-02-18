using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Models
{
    public class Reservation
    {
        public string Id;
        public string UserId;
        public string ServiceId;
        public string NumHours;
        public string Latitude;
        public string Longitude;
        public string ReserveTs;
        public string StartTs;

        public string ServiceName;
        public string UserName;
        public string StartDate;
        public string EndDate;
        public string ReserveDate;

        public string CheckinAt;
        public string CheckoutAt;

        public string CheckinAtDate;
        public string CheckoutAtDate;
        
        public void Insert(IDbConnection conn)
        {
            try
            {
                string query = "INSERT INTO reservation(user_id,service_id,num_hours,latitude,longitude,reserve_ts,start_ts)";
                query += " VALUES(@UserId,@ServiceId,@NumHours,@Latitude,@Longitude,@ReserveTs,@StartTs)";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@UserId", UserId);
                comm.Parameters.AddWithValue("@ServiceId", ServiceId);
                comm.Parameters.AddWithValue("@NumHours", NumHours);
                comm.Parameters.AddWithValue("@Latitude", Latitude);
                comm.Parameters.AddWithValue("@Longitude", Longitude);
                comm.Parameters.AddWithValue("@ReserveTs", ReserveTs);
                comm.Parameters.AddWithValue("@StartTs", StartTs);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(IDbConnection conn)
        {
            try
            {
                string query = "UPDATE reservation SET service_id=@ServiceId,num_hours=@NumHours,start_ts=@StartTs WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@ServiceId", ServiceId);
                comm.Parameters.AddWithValue("@NumHours", NumHours);
                comm.Parameters.AddWithValue("@StartTs", StartTs);
                comm.Parameters.AddWithValue("@Id", Id);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<dynamic> GetUpcomingReservations(string userId, IDbConnection conn)
        {
            try
            {
                string query = "SELECT s.name AS service_name,s.image_url,r.* FROM bookingservice s,reservation r WHERE r.user_id=@UserId";
                query += " AND UNIX_TIMESTAMP()<r.start_ts AND r.service_id=s.id AND r.is_cancel=0 ORDER BY r.start_ts ASC";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@UserId", userId);
                IDataReader reader = comm.ExecuteReader();
                List<dynamic> reservations = new List<dynamic>();
                while (reader.Read())
                {
                    var x=new
                    {
                        id = reader["id"].ToString(),
                        user_id = reader["user_id"].ToString(),
                        service_id = reader["service_id"].ToString(),
                        num_hours = reader["num_hours"].ToString(),
                        start_ts = reader["start_ts"].ToString(),
                        reserve_ts = reader["reserve_ts"].ToString(),
                        service_name = reader["service_name"].ToString(),
                        checkin_at = reader["checkin_at"].ToString(),
                        checkout_at = reader["checkout_at"].ToString(),
                        cancel_at = reader["cancel_at"].ToString(),
                        is_cancel = reader["is_cancel"].ToString(),
                        image_url = reader["image_url"].ToString(),
                    };
                    reservations.Add(x);
                }
                reader.Close();
                return reservations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<dynamic> GetPreviousReservations(string userId, IDbConnection conn)
        {
            try
            {
                string query = "SELECT s.name AS service_name,s.image_url,r.* FROM bookingservice s,reservation r WHERE r.user_id=@UserId";
                query += " AND UNIX_TIMESTAMP()>=r.start_ts AND r.service_id=s.id ORDER BY r.start_ts DESC LIMIT 0,30";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@UserId", userId);
                IDataReader reader = comm.ExecuteReader();
                List<dynamic> reservations = new List<dynamic>();
                while (reader.Read())
                {
                    var x = new
                    {
                        id = reader["id"].ToString(),
                        user_id = reader["user_id"].ToString(),
                        service_id = reader["service_id"].ToString(),
                        num_hours = reader["num_hours"].ToString(),
                        start_ts = reader["start_ts"].ToString(),
                        reserve_ts = reader["reserve_ts"].ToString(),
                        service_name = reader["service_name"].ToString(),
                        checkin_at = reader["checkin_at"].ToString(),
                        checkout_at = reader["checkout_at"].ToString(),
                        cancel_at = reader["cancel_at"].ToString(),
                        is_cancel=reader["is_cancel"].ToString(),
                        image_url = reader["image_url"].ToString(),
                    };
                    reservations.Add(x);
                }
                reader.Close();
                return reservations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
