using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatronageZadanie2Client.Models;
using PatronageZadanie2Client.Configuration;
using Microsoft.Extensions.Options;

namespace PatronageZadanie2Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppSettings appSettings;

        public ClientController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<FizzBuzzResult>> Get([FromQuery] string number)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(appSettings.BaseAddress)
            };
            client.DefaultRequestHeaders.Accept.Clear();

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
