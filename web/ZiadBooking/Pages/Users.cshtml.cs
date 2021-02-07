using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZiadBooking.Pages
{
    public class UsersModel : PageModel
    {
        public void OnGet()
        {
            Models.SessionHelper.RedirectIfNotLoggedIn(HttpContext);
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                db.Open();
                ViewData["Users"] = Models.User.GetAllUsers(db.Connection);
                db.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
        }
    }
}