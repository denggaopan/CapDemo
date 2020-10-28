using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CapDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        //[NonAction]
        //[CapSubscribe("test.show.time")]
        //public object ReceiveMessage(dynamic data)
        //{
        //    var time = (DateTime)data.Time;
        //    var message = (string)data.Message;
        //    Console.WriteLine("message time is:" + time + ", message is" + message);
        //    Thread.Sleep(3000);
        //    return new { Time1 = time, Time2 = DateTime.Now, IsSuccess = true };
        //}

        [NonAction]
        [CapSubscribe("test.show.time2")]
        public void ReceiveMessage2(dynamic data)
        {
            var time1 = (DateTime)data.Time1;
            var time2 = (DateTime)data.Time2;
            var isSuccess = (bool)data.IsSuccess;
            if (isSuccess)
            {
                Console.WriteLine($"time1:{ time1},time2:{ time2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
