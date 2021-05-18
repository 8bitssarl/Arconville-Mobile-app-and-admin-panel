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
    public class SubscriptionRequestModel : PageModel
    {
        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                string id = Request.Query["id"];
                string action = Request.Query["action"];
                if (id == null || action==null)
                {
                    ViewData["Message"] = "Invalid request";
                    return;
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                if (action == "confirm")
                {
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM subscriptionrequest WHERE id=" + id;
                    comm.ExecuteNonQuery();
                    
                    db.Close();
                    Response.Redirect("Users");
                    return;
                }
                else if (action == "cancel")
                {
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = "DELETE FROM subscriptionrequest WHERE id=" + id;
                    comm.ExecuteNonQuery();

                    db.Close();
                    Response.Redirect("Users");
                    return;
                }
                else
                {
                    ViewData["Message"] = "Invalid request";
                }
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}