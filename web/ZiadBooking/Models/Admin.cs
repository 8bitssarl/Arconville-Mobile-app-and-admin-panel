using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Models
{
    public class Admin
    {
        public string Id;
        public string Name;
        public string Email;
        public string Password;
        public string UserType;
        
        public void Insert(IDbConnection conn)
        {
            try
            {
                string query = "INSERT INTO `admin`(name,email,password,user_type)";
                query += " VALUES(@Name,@Email,@Password,@UserType)";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Name", Name);
                comm.Parameters.AddWithValue("@Email", Email);
                comm.Parameters.AddWithValue("@Password", Password);
                comm.Parameters.AddWithValue("@UserType", UserType);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Admin> GetAll(IDbConnection conn)
        {
            List<Admin> products = new List<Admin>();
            string query = "SELECT * FROM `admin` ORDER BY Name";
            IDbCommand comm = conn.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Admin cntr = new Admin()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString(),
                    Email = reader["email"].ToString(),
                    Password = reader["password"].ToString(),
                    UserType = reader["user_type"].ToString(),
                };
                products.Add(cntr);
            }
            reader.Close();
            return products;
        }

        public static Admin GetByCredentials(string email,string password, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `admin` WHERE email=@Email AND password=@Password";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Email", email);
                comm.Parameters.AddWithValue("@Password", password);
                IDataReader reader = comm.ExecuteReader();
                Admin cntr = null;
                if (reader.Read())
                {
                    cntr = new Admin()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        UserType = reader["user_type"].ToString(),
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

        public static Admin GetById(string Id, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `admin` WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Id", Id);
                IDataReader reader = comm.ExecuteReader();
                Admin cntr = null;
                if (reader.Read())
                {
                    cntr = new Admin()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        UserType = reader["user_type"].ToString(),
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

        public static Admin GetByEmail(string Email, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `admin` WHERE email=@Email";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Email", Email);
                IDataReader reader = comm.ExecuteReader();
                Admin cntr = null;
                if (reader.Read())
                {
                    cntr = new Admin()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        UserType = reader["user_type"].ToString(),
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
