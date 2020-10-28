using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapService2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [NonAction]
        [CapSubscribe("test.show.time3")]
        public object Receive(dynamic data)
        {
            var time = (DateTime)data.Time;
            var message = (string)data.Message;
            Console.WriteLine("svc2 message time is:" + time + ", message is " + message);
            return data;
        }
    }
}
