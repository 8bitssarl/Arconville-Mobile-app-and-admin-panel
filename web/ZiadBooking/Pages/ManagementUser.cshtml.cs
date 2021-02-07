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
    public class ManagementUserModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            string query = "SELECT * FROM userauth WHERE user_id=" + userId;
            MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            Models.GenericModel gdm = new Models.GenericModel();
            if (reader.Read())
            {
                gdm.CreateFromReader(reader);
            }
            reader.Close();
            ViewData["UserAuth"] = gdm;
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
                string user_type = Request.Form["user_type"];

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.Admin editUser = null;
                if (id.CompareTo("0") != 0)
                {
                    editUser = Models.Admin.GetById(id, db.Connection);
                    if (editUser == null)
                    {
                        db.Close();
                        ViewData["Message"] = "User not found";
                        return;
                    }
                }
                Models.Admin user = Models.Admin.GetByEmail(email, db.Connection);
                if (user != null && editUser!=null && user.Id!=editUser.Id)
                {
                    db.Close();
                    ViewData["Message"] = "Email already registered";
                    return;
                }
                user = new Models.Admin();
                user.Name = name;
                user.Email = email;
                user.Password = "";
                user.UserType = user_type;
                if (!string.IsNullOrEmpty(password))
                {
                    user.Password = password;
                }
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
                    string query = "UPDATE `admin` SET name=@Name,email=@Email,password=@Password,user_type=@UserType WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id",id);
                    comm.Parameters.AddWithValue("@Name", user.Name);
                    comm.Parameters.AddWithValue("@Email", user.Email);
                    comm.Parameters.AddWithValue("@Password", user.Password);
                    comm.Parameters.AddWithValue("@UserType", user.UserType);
                    comm.ExecuteNonQuery();
                }


                Models.Admin adm = Models.Admin.GetByEmail(email, db.Connection);
                string query2 = "DELETE FROM userauth WHERE user_id=" + adm.Id;
                IDbCommand comm2 = db.Connection.CreateCommand();
                comm2.CommandText = query2;
                comm2.ExecuteNonQuery();

                query2 = "INSERT INTO userauth(user_id,report_allreservations,report_noshow,report_cancellations,report_clientsinside,report_subscriptionsended,report_subscriptionsending)";
                query2 += " VALUES(@user_id,@report_allreservations,@report_noshow,@report_cancellations,@report_clientsinside,@report_subscriptionsended,@report_subscriptionsending)";
                MySqlCommand comm3 = (MySqlCommand)db.Connection.CreateCommand();
                comm3.CommandText = query2;
                comm3.Parameters.AddWithValue("@user_id",adm.Id);
                comm3.Parameters.AddWithValue("@report_allreservations",(string)Request.Form["report_allreservations"]==null?"0":"1");
                comm3.Parameters.AddWithValue("@report_noshow", (string)Request.Form["report_noshow"] == null ? "0" : "1");
                comm3.Parameters.AddWithValue("@report_cancellations", (string)Request.Form["report_cancellations"] == null ? "0" : "1");
                comm3.Parameters.AddWithValue("@report_clientsinside", (string)Request.Form["report_clientsinside"] == null ? "0" : "1");
                comm3.Parameters.AddWithValue("@report_subscriptionsended", (string)Request.Form["report_subscriptionsended"] == null ? "0" : "1");
                comm3.Parameters.AddWithValue("@report_subscriptionsending", (string)Request.Form["report_subscriptionsending"] == null ? "0" : "1");
                comm3.ExecuteNonQuery();

                db.Close();
                Response.Redirect("ManagementUsers");
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
                    comm.CommandText = "DELETE FROM `admin` WHERE id=" + id;
                    comm.ExecuteNonQuery();
                    db.Close();
                    Response.Redirect("ManagementUsers");
                    return;
                }
                if (action == "edit")
                {
                    Models.Admin usr = Models.Admin.GetById(id, db.Connection);
                    if (usr != null)
                    {
                        GenerateDataModel(id, db);
                    }
                    db.Close();
                    if (usr == null)
                    {
                        Response.Redirect("ManagementUsers");
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