using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class PackagesModel : PageModel
    {
        private void GenerateDataModel(DatabaseHelper db)
        {
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
                };
                packages.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Packages"] = packages;
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