using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _capPub;

        public ValuesController(ICapPublisher capPub)
        {
            _capPub = capPub;
        }

        [NonAction]
        [CapSubscribe("test.show.time")]
        public object Receive(dynamic data)
        {
            var time = (DateTime)data.Time;
            var message = (string)data.Message;
            Console.WriteLine("svc1 message time is:" + time + ", message is " + message);
            
            Thread.Sleep(1000);
            return new { Time1 = time, Time2 = DateTime.Now, IsSuccess = true };
        }


    }
}
