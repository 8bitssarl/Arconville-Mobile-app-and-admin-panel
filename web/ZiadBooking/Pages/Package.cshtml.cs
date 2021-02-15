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
    public class PackageModel : PageModel
    {
        private void GenerateDataModel(string packageId,DatabaseHelper db)
        {
            List<Models.BookingService> services = new List<Models.BookingService>();
            string query = "SELECT * FROM bookingservice ORDER BY name";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.BookingService x = new Models.BookingService()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString()
                };
                services.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Services"] = services;

            List<Models.PackageService> packageServices = new List<Models.PackageService>();
            if (packageId.CompareTo("0") != 0)
            {
                query = "SELECT * FROM packageservice WHERE package_id="+packageId;
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Models.PackageService x = new Models.PackageService()
                    {
                        PackageId = reader["package_id"].ToString(),
                        ServiceId = reader["service_id"].ToString()
                    };
                    packageServices.Add(x);
                }
                reader.Close();
                comm.Dispose();
            }
            ViewData["PackageServices"] = packageServices;
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
                string title = Request.Form["title"];
                string amount = Request.Form["amount"];
                string duration = Request.Form["duration"];
                string service = Request.Form["service[]"];
                string featured = Request.Form["featured"];
                string location_text = Request.Form["location_text"];
                string latitude = Request.Form["latitude"];
                string longitude = Request.Form["longitude"];
                if (service == null)
                {
                    service = "";
                }

                if (featured == null)
                {
                    featured = "0";
                }

                string[] serviceVals = service.Split(',');

                string profile_pic_url = GetProfilePicImageUrl();
                profile_pic_url = profile_pic_url.Replace('\\', '/');

                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.Package editUser = null;
                if (id.CompareTo("0") != 0)
                {
                    editUser = Models.Package.GetById(id, db.Connection);
                    if (editUser == null)
                    {
                        db.Close();
                        ViewData["Message"] = "Package not found";
                        return;
                    }

                    if (string.IsNullOrEmpty(profile_pic_url))
                    {
                        profile_pic_url = editUser.ImageUrl;
                    }
                }
                Models.Package user = new Models.Package();
                user.Title = title;
                user.LocationText = location_text;
                user.Latitude = latitude;
                user.Longitude = longitude;
                if (serviceVals.Length >= 1 && serviceVals[0].Trim().CompareTo("") != 0)
                {
                    user.ServiceId = serviceVals[0].Trim();
                }
                else
                {
                    user.ServiceId = "0";
                }
                user.NumMonths = duration;
                user.Amount = amount;
                user.Featured = featured;
                user.ImageUrl = profile_pic_url;
                if (id.CompareTo("0") == 0)
                {
                    string query = "INSERT INTO `package`(title,service_id,num_months,amount,is_featured,location_text,latitude,longitude,image_url) VALUES(@Title,@ServiceId,@NumMonths,@Amount,@Featured,@LocationText,@Latitude,@Longitude,@ImageUrl)";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Title", user.Title);
                    comm.Parameters.AddWithValue("@ServiceId", user.ServiceId);
                    comm.Parameters.AddWithValue("@NumMonths", user.NumMonths);
                    comm.Parameters.AddWithValue("@Amount", user.Amount);
                    comm.Parameters.AddWithValue("@Featured", user.Featured);
                    comm.Parameters.AddWithValue("@LocationText", location_text);
                    comm.Parameters.AddWithValue("@Latitude", latitude);
                    comm.Parameters.AddWithValue("@Longitude", longitude);
                    comm.Parameters.AddWithValue("@ImageUrl", user.ImageUrl);
                    comm.ExecuteNonQuery();

                    query = "SELECT * FROM package WHERE title=@Title";
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.Parameters.AddWithValue("@Title", user.Title);
                    comm.CommandText = query;
                    IDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        id = reader["id"].ToString();
                    }
                    reader.Close();
                    comm.Dispose();
                }
                else
                {
                    string query = "UPDATE `package` SET title=@Title,service_id=@ServiceId,num_months=@NumMonths,amount=@Amount,is_featured=@Featured,location_text=@LocationText,latitude=@Latitude,longitude=@Longitude,image_url=@ImageUrl WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Title", user.Title);
                    comm.Parameters.AddWithValue("@ServiceId", user.ServiceId);
                    comm.Parameters.AddWithValue("@NumMonths", user.NumMonths);
                    comm.Parameters.AddWithValue("@Amount", user.Amount);
                    comm.Parameters.AddWithValue("@Featured", user.Featured);
                    comm.Parameters.AddWithValue("@LocationText", location_text);
                    comm.Parameters.AddWithValue("@Latitude", latitude);
                    comm.Parameters.AddWithValue("@Longitude", longitude);
                    comm.Parameters.AddWithValue("@ImageUrl", user.ImageUrl);
                    comm.ExecuteNonQuery();

                    query = "DELETE FROM packageservice WHERE package_id=" + id;
                    comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.ExecuteNonQuery();
                }

                for (int x = 0; x < serviceVals.Length; x++)
                {
                    string sv = serviceVals[x].Trim();
                    if (sv.CompareTo("") == 0)
                    {
                        continue;
                    }

                    string query = "INSERT INTO packageservice(package_id,service_id) VALUES(" + id + "," + sv + ")";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.ExecuteNonQuery();
                    comm.Dispose();
                }

                GenerateDataModel(id,db);
                db.Close();
                Response.Redirect("Packages");
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
                    comm.CommandText = "DELETE FROM package WHERE id=" + id;
                    comm.ExecuteNonQuery();
                    db.Close();
                    Response.Redirect("Packages");
                    return;
                }
                if (action == "edit")
                {
                    Models.Package usr = Models.Package.GetById(id, db.Connection);
                    if (usr == null)
                    {
                        db.Close();
                        Response.Redirect("Packages");
                        return;
                    }
                    ViewData["Package"] = usr;
                }
                else
                {
                    ViewData["Package"] = null;
                }
                GenerateDataModel(id,db);
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}