using System.Data;
using MySql.Data.MySqlClient;

namespace ZiadBooking
{
    public class DatabaseHelper
    {
        public static string ConnectionString;

        public static string GetConnectionString()
        {
            //return @"Server = USMANILAPTOP2\SQLEXPRESS; Database = hdrx; User Id = sa; Password = master123";
            //return System.Configuration.ConfigurationManager.AppSettings["connStr"];
            return ConnectionString;
        }

        private MySqlConnection conn = null;

        public void Open()
        {
            conn = new MySqlConnection(GetConnectionString());
            conn.Open();
        }

        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return conn;
            }
        }
    }
}