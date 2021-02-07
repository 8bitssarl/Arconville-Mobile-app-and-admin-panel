using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZiadBooking.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            if (Models.SessionHelper.GetString(HttpContext, "user_id") != null)
            {
                HttpContext.Session.Remove("user_id");
            }
            Response.Redirect("Login");
        }
    }
}