using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;

namespace ZiadBooking.Pages
{
    public class TrainersModel : PageModel
    {
        private void GenerateDataModel(string userId,string time,string activity,List<Models.GenericModel> TimeList, DatabaseHelper db)
        {
            


            ViewData["Time"] = TimeList;
            ViewData["selectedTime"] = time;
            ViewData["selectedActivity"] = activity;

            /*  Booking Services */
            List<Models.GenericModel> ActivityList = new List<Models.GenericModel>();
            string query = $"SELECT `id`, `name`, `can_book_online`, `image_url`, `isSubscribedOnline`, `isSuspended`, `rHours`, `suspentionDate` FROM `bookingservice`";
            IDbCommand comm = db.Connection.CreateCommand();
            comm.CommandText = query;
            IDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Models.GenericModel x = new Models.GenericModel();
                x.CreateFromReader(reader);
                ActivityList.Add(x);
            }
            reader.Close();
            comm.Dispose();
            ViewData["Activity"] = ActivityList;

            
        }
        public void OnGet()
        {
            try
            {
                string userId = Request.Query["user_id"];
                if (userId == null)
                {
                    userId = "1";
                }
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                GenerateDataModel(userId,null,null, new List<Models.GenericModel>(), db);
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }

        public void OnPost()
        {
            try
            {
                List<Models.GenericModel> TimeList = new List<Models.GenericModel>();
                string userId = Request.Query["user_id"];
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                if (userId == null)
                {
                    userId = "1";
                }
                string time = Request.Form["align"];
                string activity = Request.Form["activity"];
                if(!string.IsNullOrEmpty(time) && !string.IsNullOrEmpty(activity))
                {
                    DateTime dt = DateTime.Now;
                    if (time == "today")
                    {
                        dt = DateTime.Now;
                    }
                    if (time == "tomorrow")
                    {
                        dt = DateTime.Now.AddDays(1);
                    }
                    if (time == "aftertomorrow")
                    {
                        dt = DateTime.Now.AddDays(1);
                    }
                    
                    string query = $"select s.fk_userId, u.name as username,u.profile_pic_url,s.fk_reservationtimeId,rt.timing,s.fk_reservationId,b.name as servicename, " +
                        $"From_UnixTime( s.reserve_ts) as Date from selected_reservationtiming s INNER JOIN reservationtiming rt " +
        $" on s.fk_reservationtimeId = rt.id INNER JOIN user u ON u.id = s.fk_userId INNER JOIN bookingservice b ON s.fk_reservationId = b.id " +
        $" where Date(From_UnixTime(s.reserve_ts))= Date('{dt.ToString("yyyy-MM-dd")}') and b.id = '{activity}'";
                    IDbCommand comm = db.Connection.CreateCommand();
                    comm.CommandText = query;
                    IDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.GenericModel x = new Models.GenericModel();
                        x.CreateFromReader(reader);
                        TimeList.Add(x);
                    }
                    reader.Close();
                    comm.Dispose();
                    ViewData["Time"] = TimeList;

                }
              
                    GenerateDataModel(userId,time,activity,TimeList, db);
                
            
                
                db.Close();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}