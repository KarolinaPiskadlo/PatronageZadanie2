using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatronageZadanie2.Models;
using Microsoft.Extensions.Logging;

namespace PatronageZadanie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        // GET: api/FizzBuzz
        [HttpGet]
        public ActionResult<FizzBuzzResult> Get([FromQuery] string number)
        {
            try
            {
                var fizzbuzz = new FizzBuzz.FizzBuzzGenerator();
                return new FizzBuzzResult(fizzbuzz.FizzBuzz(number));
            }
            catch (Exception)
            {
                return new FizzBuzzResult("Bad Request");
            }
        }

        // GET: api/FizzBuzz/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FizzBuzz
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FizzBuzz/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
