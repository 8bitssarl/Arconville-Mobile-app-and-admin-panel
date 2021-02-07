using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiadBooking.Models
{
    public class Helper
    {
        public static DateTime GetFromDatabaseDateTime(string str)
        {
            string[] vals = str.Split(" ");
            vals = vals[0].Split("-");
            int year = int.Parse(vals[0]);
            int month = int.Parse(vals[1]);
            int day = int.Parse(vals[2]);

            return new DateTime(year, month, day, 0, 0, 0);
        }

        public static string GetDatabaseDate(DateTime dt)
        {
            string dbTime = "";
            dbTime = dt.Year.ToString() + "-";
            if (dt.Month < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Month.ToString() + "-";
            if (dt.Day < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Day.ToString();
            return dbTime;
        }

        public static string GetDatabaseDateTime(DateTime dt)
        {
            string dbTime = GetDatabaseDate(dt)+" ";
            /*dbTime = dt.Year.ToString()+"-";
            if (dt.Month < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Month.ToString() + "-";
            if (dt.Year < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Day.ToString() + " ";*/
            if (dt.Hour < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Hour.ToString() + ":";
            if (dt.Minute < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Minute.ToString() + ":";
            if (dt.Second < 10)
            {
                dbTime += "0";
            }
            dbTime += dt.Second.ToString();
            return dbTime;
        }

        public static long UnixTimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        public static DateTime DateTimeFromUnixTimestamp(long ts)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(ts*1000).ToLocalTime();
            return dtDateTime;
        }
    }
}
