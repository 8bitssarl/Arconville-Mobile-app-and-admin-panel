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
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                if (id.CompareTo("0") != 0)
                {
                    string query = "SELECT id FROM bookingservice id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    IDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        db.Close();
                        ViewData["Message"] = "User not found";
                        return;
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
                    string query = "INSERT INTO `bookingservice`(name,can_book_online)";
                    query += " VALUES(@Name,@CanBookOnline)";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Name",name);
                    comm.Parameters.AddWithValue("@CanBookOnline", can_book_online);
                    comm.ExecuteNonQuery();
                }
                else
                {
                    string query = "UPDATE `bookingservice` SET name=@Name,can_book_online=@CanBookOnline WHERE id=@Id";
                    MySqlCommand comm = (MySqlCommand)db.Connection.CreateCommand();
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("@Id", id);
                    comm.Parameters.AddWithValue("@Name", name);
                    comm.Parameters.AddWithValue("@CanBookOnline", can_book_online);
                    comm.ExecuteNonQuery();
                }
                db.Close();
                Response.Redirect("BookingServices");
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
                    Response.Redirect("BookingServices");
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