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
    public class BookingServiceModel : PageModel
    {
        private void GenerateDataModel(string userId,DatabaseHelper db)
        {
            string query = "SELECT * FROM bookingservice WHERE id=" + userId;
            MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            Models.GenericModel gdm = new Models.GenericModel();
            if (reader.Read())
            {
                gdm.CreateFromReader(reader);
                ViewData["Service"] = gdm;
            }
            else
            {
                ViewData["Service"] = null;
            }
            reader.Close();
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
                string can_book_online = Request.Form["can_book_online"];
                if (can_book_online == null)
                {
                    can_book_online = "0";
                }
                string profile_pic_url = GetProfilePicImageUrl();
                profile_pic_url = profile_pic_url.Replace('\\', '/');
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                if (id.CompareTo("0") != 0)
                {
                    string query = "SELECT id,image_url FROM bookingservice WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    IDataReader reader = comm.ExecuteReader();
                    if (!reader.Read())
                    {
                        reader.Close();
                        db.Close();
                        ViewData["Message"] = "Service not found";
                        return;
                    }
                    if (string.IsNullOrEmpty(profile_pic_url))
                    {
                        profile_pic_url = reader["image_url"].ToString();
                    }
                    reader.Close();
                }
                Models.GenericModel gmd = new Models.GenericModel();
                gmd.values.Add("id", id);
                gmd.values.Add("name",name);
                gmd.values.Add("can_book_online", can_book_online);
                ViewData["Service"] = gmd;
                if (id.CompareTo("0") == 0)
                {
                    string query = "INSERT INTO `bookingservice`(name,can_book_online,image_url)";
                    query += " VALUES(@Name,@CanBookOnline,@ImageUrl)";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Name",name);
                    comm.Parameters.AddWithValue("@CanBookOnline", can_book_online);
                    comm.Parameters.AddWithValue("@ImageUrl", profile_pic_url);
                    comm.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE `bookingservice` SET name=@Name,can_book_online=@CanBookOnline,image_url=@ImageUrl WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Name", name);
                    comm.Parameters.AddWithValue("@CanBookOnline", can_book_online);
                    comm.Parameters.AddWithValue("@ImageUrl", profile_pic_url);
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
                    comm.CommandText = "DELETE FROM `bookingservice` WHERE id=" + id;
                    comm.ExecuteNonQuery();
                    db.Close();
                    //Response.Redirect("BookingServices");
                    Response.Redirect("Users");
                    return;
                }
                if (action == "edit")
                {
                    GenerateDataModel(id, db);
                    db.Close();
                    /*if (usr == null)
                    {
                        Response.Redirect("BookingServices");
                        return;
                    }*/
                }
                else
                {
                    ViewData["Service"] = null;
                }
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}