using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZiadBooking.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZiadBookingApiController : ControllerBase
    {
        protected ApiResponseModel CreateApiResponseModel(int status,string msg,object data)
        {
            return new ApiResponseModel()
            {
                status = status,
                msg = msg,
                data = data
            };
        }
    }
}