using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiadBooking.Models
{
    public class SessionHelper
    {
        public static string KEY_USER_ID = "user_id";
        public static string KEY_USER_TYPE = "user_type";
        public static string KEY_USER_NAME = "user_name";

        public static void SetString(Microsoft.AspNetCore.Http.HttpContext ctx,string key,string val)
        {
            Microsoft.AspNetCore.Http.ISession session = ctx.Session;
            session.Set(key, System.Text.Encoding.ASCII.GetBytes(val));
        }

        public static string GetString(Microsoft.AspNetCore.Http.HttpContext ctx,string key)
        {
            Microsoft.AspNetCore.Http.ISession session = ctx.Session;
            byte[] data;
            if (session.TryGetValue(key,out data))
            {
                return System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
            }
            return null;
        }

        public static bool IsUserLoggedIn(Microsoft.AspNetCore.Http.HttpContext ctx)
        {
            Microsoft.AspNetCore.Http.ISession session = ctx.Session;
            return GetUserId(ctx) != null;
        }

        public static void RedirectIfNotLoggedIn(Microsoft.AspNetCore.Http.HttpContext ctx)
        {
            if (!IsUserLoggedIn(ctx))
            {
                ctx.Response.Redirect("Login");
            }
        }

        public static string GetUserId(Microsoft.AspNetCore.Http.HttpContext ctx)
        {
            return GetString(ctx, KEY_USER_ID);
        }

        public static void SetUserId(Microsoft.AspNetCore.Http.HttpContext ctx,string id)
        {
            SetString(ctx, KEY_USER_ID, id);
        }

        public static string GetUserName(Microsoft.AspNetCore.Http.HttpContext ctx)
        {
            return GetString(ctx, KEY_USER_NAME);
        }

        public static void SetUserName(Microsoft.AspNetCore.Http.HttpContext ctx, string id)
        {
            SetString(ctx, KEY_USER_NAME, id);
        }

        public static string GetUserType(Microsoft.AspNetCore.Http.HttpContext ctx)
        {
            return GetString(ctx, KEY_USER_TYPE);
        }

        public static void SetUserType(Microsoft.AspNetCore.Http.HttpContext ctx, string tp)
        {
            SetString(ctx, KEY_USER_TYPE, tp);
        }

        public static bool CanSeePage(Microsoft.AspNetCore.Http.HttpContext ctx, string tp)
        {
            string ut = GetUserType(ctx);
            if (ut == null)
            {
                return false;
            }
            if (ut.CompareTo("reception") == 0)
            {
                if (tp.CompareTo("reception") == 0)
                {
                    
                    return true;

                }
            }
            if (ut.CompareTo("trainer") == 0)
            {
                if (tp.CompareTo("Trainer") == 0 || tp.CompareTo("trainer")==0)
                {
                    return true;
                }
            }
            else if (ut.CompareTo("admin") == 0 || ut.CompareTo("ceo")==0)
            {
                return true;
            }
            else if (ut.CompareTo("Client Management") == 0 && tp=="users")
            {
                return true;
            }
            return false;
        }
    }
}
