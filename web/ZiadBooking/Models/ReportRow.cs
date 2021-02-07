using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiadBooking.Models
{
    public class ReportRow
    {
        private System.Collections.Hashtable ht = new System.Collections.Hashtable();

        public void SetItem(string key, string val)
        {
            ht.Add(key, val);
        }

        public string GetItem(string key)
        {
            if (ht[key] == null)
            {
                return "";
            }
            return ht[key].ToString();
        }
    }
}
