using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly ICapPublisher _capPub;

        public PublishController(ICapPublisher capPub)
        {
            _capPub = capPub;
        }

        [HttpGet("send")]
        public IActionResult SendMessage(string message)
        {
            var now = DateTime.Now;
            var data = new { Time = now, Message = message };
            _capPub.Publish("test.show.time", data, "test.show.time2");

            Console.WriteLine($"------------\npublish time:{now}");
            return Ok();
        }

        [HttpGet("send2")]
        public IActionResult SendMessage2(string message)
        {
            var now = DateTime.Now;
            var data = new { Time = now, Message = message };
            _capPub.Publish("test.show.time3", data);

            Console.WriteLine($"------------\npublish time:{now}");
            return Ok();
        }




        [HttpGet("send3")]
        public IActionResult SendMessage3(string message)
        {
            var now = DateTime.Now;
            var data = new { Time = now, Message = message };
            _capPub.Publish("test.show.time", data);
            _capPub.Publish("test.show.time3", data);

            Console.WriteLine($"------------\npublish time:{now}");
            return Ok();
        }
    }
}
