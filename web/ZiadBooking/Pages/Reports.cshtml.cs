using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking.Pages
{
    public class ReportsModel : PageModel
    {
        private void GenerateDataModel(string reportType,DatabaseHelper db)
        {
            IDbCommand comm = db.Connection.CreateCommand();
            string query = "";
            IDataReader reader = null;
            if (reportType.CompareTo("allreservations") == 0)
            {
                ViewData["ReportTitle"] = "Report - All Reservations";
                query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.service_id=s.id AND r.user_id=u.id";
                query += " AND UNIX_TIMESTAMP()<r.start_ts ORDER BY r.start_ts ASC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                List<Models.ReportRow> data = new List<Models.ReportRow>();
                while (reader.Read())
                {
                    long ts = long.Parse(reader["start_ts"].ToString());
                    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                    string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                    ts = long.Parse(reader["reserve_ts"].ToString());
                    dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
                    string checkinStr = "";
                    string checkoutStr = "";
                    try
                    {
                        ts = long.Parse(reader["checkin_at"].ToString());
                        checkinStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    try
                    {
                        ts = long.Parse(reader["checkout_at"].ToString());
                        checkoutStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    Models.ReportRow row = new Models.ReportRow();
                    row.SetItem("UserName", reader["user_name"].ToString());
                    row.SetItem("ServiceName", reader["service_name"].ToString());
                    row.SetItem("NumHours", reader["num_hours"].ToString());
                    row.SetItem("StartDate", dateStr);
                    row.SetItem("EndDate", endStr);
                    row.SetItem("ReserveDate", reserveStr);
                    row.SetItem("CheckinAt", reader["checkin_at"].ToString());
                    row.SetItem("CheckinAtDate", checkinStr);
                    row.SetItem("CheckoutAt", reader["checkout_at"].ToString());
                    row.SetItem("CheckoutAtDate", checkoutStr);
                    row.SetItem("Latitude", reader["latitude"].ToString());
                    row.SetItem("Longitude", reader["longitude"].ToString());
                    data.Add(row);
                }
                reader.Close();
                ViewData["Data"] = data;
            }
            else if (reportType.CompareTo("noshow") == 0)
            {
                ViewData["ReportTitle"] = "Report - No Show";

                query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.service_id=s.id AND r.user_id=u.id";
                query += " AND UNIX_TIMESTAMP()>r.start_ts AND r.is_cancel=0 AND r.checkin_at IS NULL ORDER BY r.start_ts DESC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                List<Models.ReportRow> data = new List<Models.ReportRow>();
                while (reader.Read())
                {
                    long ts = long.Parse(reader["start_ts"].ToString());
                    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                    string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                    ts = long.Parse(reader["reserve_ts"].ToString());
                    dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
                    string checkinStr = "";
                    string checkoutStr = "";
                    try
                    {
                        ts = long.Parse(reader["checkin_at"].ToString());
                        checkinStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    try
                    {
                        ts = long.Parse(reader["checkout_at"].ToString());
                        checkoutStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    Models.ReportRow row = new Models.ReportRow();
                    row.SetItem("ServiceName", reader["service_name"].ToString());
                    row.SetItem("UserName", reader["user_name"].ToString());
                    row.SetItem("NumHours", reader["num_hours"].ToString());
                    row.SetItem("StartDate", dateStr);
                    row.SetItem("EndDate", endStr);
                    row.SetItem("ReserveDate", reserveStr);
                    data.Add(row);
                }
                reader.Close();
                ViewData["Data"] = data;
            }
            else if (reportType.CompareTo("cancellations") == 0)
            {
                ViewData["ReportTitle"] = "Report - Cancellations";

                query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.service_id=s.id AND r.user_id=u.id";
                query += " AND r.is_cancel=1 ORDER BY r.start_ts DESC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                List<Models.ReportRow> data = new List<Models.ReportRow>();
                while (reader.Read())
                {
                    long ts = long.Parse(reader["start_ts"].ToString());
                    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                    string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                    ts = long.Parse(reader["reserve_ts"].ToString());
                    dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
                    string cancelStr = "";
                    try
                    {
                        ts = long.Parse(reader["cancel_at"].ToString());
                        cancelStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    Models.ReportRow row = new Models.ReportRow();
                    row.SetItem("ServiceName", reader["service_name"].ToString());
                    row.SetItem("UserName", reader["user_name"].ToString());
                    row.SetItem("NumHours", reader["num_hours"].ToString());
                    row.SetItem("StartDate", dateStr);
                    row.SetItem("EndDate", endStr);
                    row.SetItem("ReserveDate", reserveStr);
                    row.SetItem("CancelDate", cancelStr);
                    data.Add(row);
                }
                reader.Close();
                ViewData["Data"] = data;
            }
            else if (reportType.CompareTo("clientsinside") == 0)
            {
                ViewData["ReportTitle"] = "Report - Clients Inside";

                query = "SELECT u.name AS user_name,s.name AS service_name,r.* FROM reservation r,bookingservice s,user u WHERE r.service_id=s.id AND r.user_id=u.id";
                query += " AND UNIX_TIMESTAMP()>r.start_ts AND r.is_cancel=0 AND r.checkin_at IS NOT NULL AND r.checkout_at IS NULL ORDER BY r.start_ts DESC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
                List<Models.ReportRow> data = new List<Models.ReportRow>();
                while (reader.Read())
                {
                    long ts = long.Parse(reader["start_ts"].ToString());
                    DateTime dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string dateStr = Models.Helper.GetDatabaseDateTime(dt);
                    string endStr = Models.Helper.GetDatabaseDateTime(dt.AddHours(double.Parse(reader["num_hours"].ToString())));
                    ts = long.Parse(reader["reserve_ts"].ToString());
                    dt = Models.Helper.DateTimeFromUnixTimestamp(ts);
                    string reserveStr = Models.Helper.GetDatabaseDateTime(dt);
                    string cancelStr = "";
                    string checkinStr = "";
                    string checkoutStr = "";
                    try
                    {
                        ts = long.Parse(reader["checkin_at"].ToString());
                        checkinStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    try
                    {
                        ts = long.Parse(reader["checkout_at"].ToString());
                        checkoutStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    try
                    {
                        ts = long.Parse(reader["cancel_at"].ToString());
                        cancelStr = Models.Helper.GetDatabaseDateTime(Models.Helper.DateTimeFromUnixTimestamp(ts));
                    }
                    catch { }
                    Models.ReportRow row = new Models.ReportRow();
                    row.SetItem("ServiceName", reader["service_name"].ToString());
                    row.SetItem("UserName", reader["user_name"].ToString());
                    row.SetItem("NumHours", reader["num_hours"].ToString());
                    row.SetItem("StartDate", dateStr);
                    row.SetItem("EndDate", endStr);
                    row.SetItem("ReserveDate", reserveStr);
                    row.SetItem("CheckinDate", checkinStr);
                    data.Add(row);
                }
                reader.Close();
                ViewData["Data"] = data;
            }
            else if (reportType.CompareTo("subsended") == 0)
            {
                ViewData["ReportTitle"] = "Report - Subscriptions Ended";

                query = "SELECT us.*,bs.name AS service_name,u.name AS user_name FROM usersubscription us,bookingservice bs,user u WHERE bs.id=us.service_id AND us.user_id=u.id ORDER BY start_ts DESC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
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
                    if (expTs >= Models.Helper.UnixTimestampFromDateTime(DateTime.Now))
                    {
                        //active
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
                    data.Add(row);
                }
                reader.Close();
                ViewData["Data"] = data;
            }
            else if (reportType.CompareTo("subsending") == 0)
            {
                int endInMonths = 1;
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
                ViewData["ReportTitle"] = "Report - Subscriptions Ending in "+endInMonths.ToString()+" Month(s)";
                query = "SELECT us.*,bs.name AS service_name,u.name AS user_name FROM usersubscription us,bookingservice bs,user u WHERE bs.id=us.service_id AND us.user_id=u.id ORDER BY start_ts DESC";
                comm = db.Connection.CreateCommand();
                comm.CommandText = query;
                reader = comm.ExecuteReader();
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
                    if (Math.Ceiling(d/30) > endInMonths)
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
                ViewData["Data"] = data;
            }
            comm.Dispose();
        }

        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                string reportType = Request.Query["type"];
                if (reportType == null)
                {
                    reportType = "allreservations";
                }
                ViewData["ReportType"] = reportType;
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(reportType, db);
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}