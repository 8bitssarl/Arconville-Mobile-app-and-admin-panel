using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class UsersModel : PageModel
    {
        private void GenerateDataModel(DatabaseHelper db)
        {
            ViewData["Users"] = Models.User.GetAllUsers(db.Connection);

            List<Models.Package> packages = new List<Models.Package>();
            string query = "SELECT p.* FROM package p ORDER BY p.title";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.Package x = new Models.Package()
                {
                    Id = reader["id"].ToString(),
                    ServiceId = reader["service_id"].ToString(),
                    NumMonths = reader["num_months"].ToString(),
                    Title = reader["title"].ToString(),
                    Amount = reader["amount"].ToString(),
                    LocationText = reader["location_text"].ToString(),
                    Latitude = reader["latitude"].ToString(),
                    Longitude = reader["longitude"].ToString(),
                    ImageUrl = reader["image_url"].ToString(),
                };
                packages.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Packages"] = packages;

            List<Models.SubscriptionRequest> subRequests = new List<Models.SubscriptionRequest>();
            query = "SELECT sr.id,sr.request_dt,p.title AS package_name,u.name AS user_name,u.phone_number AS phone_number FROM package p,user u,subscriptionrequest sr WHERE sr.user_id=u.id AND sr.package_id=p.id ORDER BY sr.request_dt DESC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var x = new Models.SubscriptionRequest()
                {
                    Id = reader["id"].ToString(),
                    UserName = reader["user_name"].ToString(),
                    PhoneNumber = reader["phone_number"].ToString(),
                    PackageName = reader["package_name"].ToString(),
                    RequestDt = reader["request_dt"].ToString(),
                };
                subRequests.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["SubscriptionRequests"] = subRequests;

            List<Models.BookingService> services = new List<Models.BookingService>();
            query = "SELECT p.* FROM bookingservice p ORDER BY p.name";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.BookingService x = new Models.BookingService()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString(),
                    CanBookOnline = reader["can_book_online"].ToString(),
                    ImageUrl = reader["image_url"].ToString(),
                };
                services.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Services"] = services;
        }

        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(db);
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

        public void OnPost()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(db);
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}