using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ZiadBooking.Pages
{
    public class IndexModel : PageModel
    {
        private void GenerateSubsEnding(DatabaseHelper db)
        {
            int endInMonths = 12;
            string sEm = Request.Query["end_months"];
            if (sEm != null)
            {
                try
                {
                    endInMonths = int.Parse(sEm);
                }
                catch { }
            }
            ViewData["EndingIn"] = endInMonths.ToString();
            ViewData["ReportTitle"] = "Report - Subscriptions Ending in " + endInMonths.ToString() + " Month(s)";
            string query = "SELECT us.*,bs.name AS service_name,u.name AS user_name FROM usersubscription us,bookingservice bs,user u WHERE bs.id=us.service_id AND us.user_id=u.id ORDER BY start_ts DESC";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            List<Models.ReportRow> data = new List<Models.ReportRow>();
            while (reader.Read())
            {
                long ts = long.Parse(reader["start_ts"].ToString());
                DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                string dateStr = Models.Helper.GetDatabaseDate(dt);
                int numMonths = int.Parse(reader["num_months"].ToString());
                DateTime dtExp = new DateTime(dt.Ticks);
                dtExp = dtExp.AddMonths(numMonths);
                string expStr = Models.Helper.GetDatabaseDate(dtExp);
                long expTs = Models.Helper.UnixTimestampFromDateTime(dtExp);
                if (expTs < Models.Helper.UnixTimestampFromDateTime(DateTime.Now))
                {
                    //expired
                    continue;
                }
                double d = dtExp.Subtract(DateTime.Now).Days;
                if (Math.Ceiling(d / 30) > endInMonths)
                {
                    //ending in more than X months
                    continue;
                }
                Models.ReportRow row = new Models.ReportRow();
                row.SetItem("ServiceName", reader["service_name"].ToString());
                row.SetItem("UserName", reader["user_name"].ToString());
                row.SetItem("NumMonths", reader["num_months"].ToString());
                row.SetItem("StartDate", dateStr);
                row.SetItem("ExpiredAt", expStr);
                row.SetItem("Details", reader["details"].ToString());
                row.SetItem("AmountPaid", reader["amount_paid"].ToString());
                row.SetItem("EndingIn", d.ToString());
                data.Add(row);
            }
            reader.Close();
            ViewData["SubsEnding"] = data;
        }

        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);

            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateSubsEnding(db);
                db.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
