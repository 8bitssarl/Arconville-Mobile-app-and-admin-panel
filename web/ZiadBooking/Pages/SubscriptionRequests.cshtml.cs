using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class SubscriptionRequestsModel : PageModel
    {
        private void GenerateDataModel(DatabaseHelper db)
        {
            List<Models.SubscriptionRequest> packages = new List<Models.SubscriptionRequest>();
            string query = "SELECT sr.id,sr.request_dt,p.title AS package_name,u.name AS user_name FROM package p,user u,subscriptionrequest sr WHERE sr.user_id=u.id AND sr.package_id=p.id ORDER BY sr.request_dt DESC";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                var x = new Models.SubscriptionRequest()
                {
                    Id = reader["id"].ToString(),
                    UserName = reader["user_name"].ToString(),
                    PackageName = reader["package_name"].ToString(),
                    RequestDt = reader["request_dt"].ToString(),
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