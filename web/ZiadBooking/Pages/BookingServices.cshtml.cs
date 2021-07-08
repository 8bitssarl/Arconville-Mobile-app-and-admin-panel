using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class BookingServicesModel : PageModel
    {
        private void GenerateDataModel(DatabaseHelper db)
        {
            List<Models.BookingService> packages = new List<Models.BookingService>();
            string query = "SELECT p.* FROM bookingservice p ORDER BY p.name";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.BookingService x = new Models.BookingService()
                {
                    Id = reader["id"].ToString(),
                    Name = reader["name"].ToString(),
                  
                    ImageUrl = reader["image_url"].ToString(),
                };
                if (reader["can_book_online"].ToString() == "0")
                    x.CanBookOnline = false;
                if (reader["can_book_online"].ToString() == "1")
                    x.CanBookOnline = true;
                packages.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Services"] = packages;
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