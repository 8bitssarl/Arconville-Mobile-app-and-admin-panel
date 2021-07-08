using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiadBooking.Controllers
{
    public class ApiResponseModel
    {
        public int status;
        public string msg;
        public object data;
    }
    public class ApiResponseModel2
    {
     
        public object Items;
        public int Count;
    }
}
