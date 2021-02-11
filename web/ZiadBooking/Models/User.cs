using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Models
{
    public class User
    {
        public string Id;
        public string Name;
        public string Email;
        public string Password;
        public string ProfilePicUrl;
        public string PhoneNumber;
        public string PhoneVerified;
        public string RegisterDt;
        public string CanAddMember;
        public string Age;
        public string DateOfBirth;
        
        public void Insert(IDbConnection conn)
        {
            try
            {
                string query = "INSERT INTO `user`(name,email,password,profile_pic_url,phone_number,phone_verified,register_dt,can_add_member,age,date_of_birth)";
                query += " VALUES(@Name,@Email,@Password,@ProfilePicUrl,@PhoneNumber,@PhoneVerified,@RegisterDt,@CanAddMember,@Age,@DateOfBirth)";
                //SqlCommand comm = (SqlCommand)conn.CreateCommand();
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Name", Name);
                comm.Parameters.AddWithValue("@Email", Email);
                comm.Parameters.AddWithValue("@Password", Password);
                comm.Parameters.AddWithValue("@ProfilePicUrl", ProfilePicUrl);
                comm.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                comm.Parameters.AddWithValue("@PhoneVerified", PhoneVerified);
                comm.Parameters.AddWithValue("@RegisterDt", RegisterDt);
                comm.Parameters.AddWithValue("@CanAddMember", CanAddMember);
                comm.Parameters.AddWithValue("@Age", Age);
                comm.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePhoneDetails(IDbConnection conn)
        {
            try
            {
                string query = "UPDATE `user` SET phone_number=@PhoneNumber,phone_verified=@PhoneVerified WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Id", Id);
                comm.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                comm.Parameters.AddWithValue("@PhoneVerified", PhoneVerified);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProfileDetails(IDbConnection conn)
        {
            try
            {
                string query = "UPDATE `user` SET name=@Name,password=@Password,profile_pic_url=@ProfilePicUrl,can_add_member=@CanAddMember,age=@Age,date_of_birth=@DateOfBirth WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Id", Id);
                comm.Parameters.AddWithValue("@Name", Name);
                comm.Parameters.AddWithValue("@Password", Password);
                comm.Parameters.AddWithValue("@ProfilePicUrl", ProfilePicUrl);
                comm.Parameters.AddWithValue("@CanAddMember", CanAddMember);
                comm.Parameters.AddWithValue("@Age", Age);
                comm.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static User GetById(string id, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `user` WHERE id=@Id";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Id", id);
                IDataReader reader = comm.ExecuteReader();
                User cntr = null;
                if (reader.Read())
                {
                    cntr = new User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        ProfilePicUrl = reader["profile_pic_url"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        PhoneVerified = reader["phone_verified"].ToString(),
                        RegisterDt = reader["register_dt"].ToString(),
                        CanAddMember = reader["can_add_member"].ToString(),
                        Age = reader["age"].ToString(),
                        DateOfBirth = reader["date_of_birth"].ToString(),
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

        public static User GetByCredentials(string email,string password, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `user` WHERE email=@Email AND password=@Password";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Email", email);
                comm.Parameters.AddWithValue("@Password", password);
                IDataReader reader = comm.ExecuteReader();
                User cntr = null;
                if (reader.Read())
                {
                    cntr = new User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        ProfilePicUrl = reader["profile_pic_url"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        PhoneVerified = reader["phone_verified"].ToString(),
                        RegisterDt = reader["register_dt"].ToString(),
                        CanAddMember = reader["can_add_member"].ToString(),
                        Age = reader["age"].ToString(),
                        DateOfBirth = reader["date_of_birth"].ToString(),
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

        public static User GetByEmail(string email, IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `user` WHERE email=@Email";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@Email", email);
                IDataReader reader = comm.ExecuteReader();
                User cntr = null;
                if (reader.Read())
                {
                    cntr = new User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        ProfilePicUrl = reader["profile_pic_url"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        PhoneVerified = reader["phone_verified"].ToString(),
                        RegisterDt = reader["register_dt"].ToString(),
                        CanAddMember = reader["can_add_member"].ToString(),
                        Age = reader["age"].ToString(),
                        DateOfBirth = reader["date_of_birth"].ToString(),
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

        public static List<User> GetAllUsers(IDbConnection conn)
        {
            try
            {
                string query = "SELECT * FROM `user` ORDER BY name";
                MySqlCommand comm = (MySqlCommand)conn.CreateCommand();
                comm.CommandText = query;
                IDataReader reader = comm.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User cntr = new User()
                    {
                        Id = reader["id"].ToString(),
                        Name = reader["name"].ToString(),
                        Email = reader["email"].ToString(),
                        Password = reader["password"].ToString(),
                        ProfilePicUrl = reader["profile_pic_url"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        PhoneVerified = reader["phone_verified"].ToString(),
                        RegisterDt = reader["register_dt"].ToString(),
                        CanAddMember = reader["can_add_member"].ToString(),
                        Age = reader["age"].ToString(),
                        DateOfBirth = reader["date_of_birth"].ToString(),
                    };
                    users.Add(cntr);
                }
                reader.Close();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
