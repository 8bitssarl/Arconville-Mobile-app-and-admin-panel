using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZiadBooking.Pages
{
    public class LoginModel : PageModel
    {
        public string Message
        {
            get;
            set;
        }

        public void OnGet()
        {
            ViewData["Message"] = "";
        }

        public void OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                Models.Admin admin = Models.Admin.GetByCredentials(username, password, db.Connection);
                db.Close();
                if (admin == null)
                {
                    Message = "Invalid username/password";
                }
                else
                {
                    Message = "Logged in";
                    Models.SessionHelper.SetUserId(HttpContext, admin.Id);
                    Models.SessionHelper.SetUserType(HttpContext, admin.UserType);
                    Models.SessionHelper.SetUserName(HttpContext, admin.Name);
                    Response.Redirect("Index");
                }
            }
            catch(Exception ex)
            {
                Message = "Exception: " + ex.Message;
            }
            ViewData["Message"] = Message;
        }
    }
}
