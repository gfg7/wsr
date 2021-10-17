using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly Random random = new Random();
        private static int max = 0;

        [Route("int")]
        public IActionResult GetInt()
        {
            if (max > 0)
                return Ok(random.Next(0, max));
            else return BadRequest("set max first");
        }

        [HttpPost, Route("setmax")]
        public void SetMax(int max = int.MaxValue)
        {
            TestController.max = max;
        }
    }
}
