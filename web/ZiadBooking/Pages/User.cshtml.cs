using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.Data;

namespace ZiadBooking.Pages
{
    public class UserModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            List<Models.GenericModel> family = new List<Models.GenericModel>();
            string query = "SELECT u.name,u.profile_pic_url,u.phone_number,'0' AS is_pending,f.relation FROM family f,user u WHERE u.id=f.child_id AND f.user_id=@user_id ORDER BY u.name";
            MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
            comm.CommandText = query;
            comm.Parameters.AddWithValue("@user_id", userId);
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.GenericModel gm = new Models.GenericModel();
                gm.CreateFromReader(reader);
                family.Add(gm);
            }
            reader.Close();
            query = "SELECT f.name,'' AS profile_pic_url,f.phone_number,'1' AS is_pending,f.relation FROM familyrequest f WHERE f.user_id=@user_id ORDER BY f.name";
            comm = (MySqlCommand)db.Connection.CreateCommand();
            comm.CommandText = query;
            comm.Parameters.AddWithValue("@user_id", userId);
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.GenericModel gm = new Models.GenericModel();
                gm.CreateFromReader(reader);
                family.Add(gm);
            }
            reader.Close();
            db.Close();
            ViewData["Family"] = family;
        }

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
                id = Request.Query["id"];
                if (id == null)
                {
                    id = "0";
                }
                string name = Request.Form["name"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];
                string phone_number = Request.Form["phone_number"];
                string phone_verified = Request.Form["phone_verified"].Count<=0 ? "0" : "1";
                string can_add_member = Request.Form["can_add_member"].Count <= 0 ? "0" : "1";
                string date_of_birth = Request.Form["date_of_birth"];
                string[] vals = date_of_birth.Split("-");
                string age = vals[0].Trim();
                string profile_pic_url = GetProfilePicImageUrl();
                profile_pic_url=profile_pic_url.Replace('\\', '/');

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.User editUser = null;
                if (id.CompareTo("0") != 0)
                {
                    editUser = Models.User.GetById(id, db.Connection);
                    if (editUser == null)
                    {
                        db.Close();
                        ViewData["Message"] = "User not found";
                        return;
                    }
                }
                Models.User user = Models.User.GetByEmail(email, db.Connection);
                if (user != null && editUser!=null && user.Id!=editUser.Id)
                {
                    db.Close();
                    ViewData["Message"] = "Email already registered";
                    return;
                }
                user = new Models.User();
                user.Name = name;
                user.Email = email;
                user.Password = "";
                if (!string.IsNullOrEmpty(password))
                {
                    user.Password = password;
                }
                user.PhoneNumber = phone_number;
                user.PhoneVerified = phone_verified;
                user.CanAddMember = can_add_member;
                user.Age = age;
                user.DateOfBirth = date_of_birth;
                user.ProfilePicUrl = profile_pic_url;
                user.RegisterDt = Models.Helper.GetDatabaseDateTime(DateTime.Now);
                ViewData["User"] = user;
                if (id.CompareTo("0") == 0)
                {
                    user.Insert(db.Connection);
                }
                else
                {
                    if (string.IsNullOrEmpty(user.Password))
                    {
                        user.Password = editUser.Password;
                    }
                    if (user.ProfilePicUrl=="")
                        user.ProfilePicUrl = editUser.ProfilePicUrl;
                    string query = "UPDATE `user` SET name=@Name,email=@Email,password=@Password,profile_pic_url=@ProfilePicUrl,can_add_member=@CanAddMember,phone_number=@PhoneNumber,phone_verified=@PhoneVerified,age=@Age,date_of_birth=@DateOfBirth WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id",id);
                    comm.Parameters.AddWithValue("@Name", user.Name);
                    comm.Parameters.AddWithValue("@Email", user.Email);
                    comm.Parameters.AddWithValue("@Password", user.Password);
                    comm.Parameters.AddWithValue("@Age", user.Age);
                    comm.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    comm.Parameters.AddWithValue("@ProfilePicUrl", user.ProfilePicUrl);
                    comm.Parameters.AddWithValue("@CanAddMember", user.CanAddMember);
                    comm.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    comm.Parameters.AddWithValue("@PhoneVerified", user.PhoneVerified);
                    comm.ExecuteNonQuery();
                }
                db.Close();
                Response.Redirect("Users");
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
                string id = Request.Query["id"];
                string action = Request.Query["action"];
                if (id == null)
                {
                    id = "0";
                }
                if (action == null)
                {
                    if (id == "0")
                    {
                        action = "add";
                    }
                    else
                    {
                        action = "edit";
                    }
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                if (action == "delete")
                {
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM user WHERE id=" + id;
                    comm.ExecuteNonQuery();
                    comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM family WHERE user_id=" + id;
                    comm.ExecuteNonQuery();
                    comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM family WHERE child_id=" + id;
                    comm.ExecuteNonQuery();
                    comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM reservation WHERE user_id=" + id;
                    comm.ExecuteNonQuery();
                    comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM userpayment WHERE user_id=" + id;
                    comm.ExecuteNonQuery();
                    comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM usersubscription WHERE user_id=" + id;
                    comm.ExecuteNonQuery();

                    db.Close();
                    Response.Redirect("Users");
                    return;
                }
                if (action == "edit")
                {
                    Models.User usr = Models.User.GetById(id, db.Connection);
                    if (usr != null)
                    {
                        GenerateDataModel(id, db);
                    }
                    db.Close();
                    if (usr == null)
                    {
                        Response.Redirect("Users");
                        return;
                    }
                    ViewData["User"] = usr;
                }
                else
                {
                    ViewData["User"] = null;
                }
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}