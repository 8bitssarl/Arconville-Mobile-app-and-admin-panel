﻿using System;
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
            query = "SELECT sr.id,sr.request_dt,p.title AS package_name,u.name AS user_name FROM package p,user u,subscriptionrequest sr WHERE sr.user_id=u.id AND sr.package_id=p.id ORDER BY sr.request_dt DESC";
            comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var x = new Models.SubscriptionRequest()
                {
                    Id = reader["id"].ToString(),
                    UserName = reader["user_name"].ToString(),
                    PackageName = reader["package_name"].ToString(),
                    RequestDt = reader["request_dt"].ToString(),
                };
                subRequests.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["SubscriptionRequests"] = subRequests;
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
    }
}