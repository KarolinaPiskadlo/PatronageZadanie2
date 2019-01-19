using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatronageZadanie2Client.Models;

namespace PatronageZadanie2Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        HttpClient client = new HttpClient();

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<FizzBuzzResult>> Get([FromQuery] string number)
        {
            client.BaseAddress = new Uri("http://localhost:53203/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            FizzBuzzResult fizzBuzzResult = null;

            var response = await client.GetAsync($"api/fizzbuzz?number={number}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<FizzBuzzResult>();
            }


            return BadRequest(response.Content.ReadAsAsync<ErrorResponse>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
