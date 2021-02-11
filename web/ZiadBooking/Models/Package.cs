using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Models
{
    public class Package
    {
        public string Id;
        public string ServiceId;
        public string Title;
        public string NumMonths;
        public string Amount;
        public string Featured;
        public string LocationText,Latitude,Longitude;
        public string ImageUrl;
        
        public static Package GetById(string id, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `package` WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Id", id);
                IDataReader reader = comm.ExecuteReader();
                Package cntr = null;
                if (reader.Read())
                {
                    cntr = new Package()
                    {
                        Id = reader["id"].ToString(),
                        Title = reader["title"].ToString(),
                        ServiceId = reader["service_id"].ToString(),
                        NumMonths = reader["num_months"].ToString(),
                        Amount = reader["amount"].ToString(),
                        Featured = reader["is_featured"].ToString(),
                        LocationText = reader["location_text"].ToString(),
                        Latitude = reader["latitude"].ToString(),
                        Longitude = reader["longitude"].ToString(),
                        ImageUrl = reader["image_url"].ToString(),
                    };

                }
                reader.Close();
                return cntr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
