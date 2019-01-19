using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatronageZadanie2.Data;
using PatronageZadanie2.Error;
using PatronageZadanie2.Models;

namespace PatronageZadanie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomController : ControllerBase
    {
        private readonly ConferenceRoomContext context;

        public ConferenceRoomController(ConferenceRoomContext context)
        {
            this.context = context;
        }

        // GET: api/conferenceroom
        [HttpGet]
        public ActionResult<IEnumerable<ConferenceRoom>> Get()
        {
            return context.ConferenceRoom.ToList();
        }

        // GET api/conferenceroom/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ConferenceRoom>> Get(int id)
        {

            var room = context.ConferenceRoom.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            return context.ConferenceRoom.Where(n => n.Id == id).ToList();
        }

        // POST api/conferenceroom
        [HttpPost]
        public void Post([FromBody] ConferenceRoomDTO conferenceRoomDTO)
        {
            var conferenceRoom = new ConferenceRoom
            {
                Name = conferenceRoomDTO.Name,
                Area = conferenceRoomDTO.Area,
                Capacity = conferenceRoomDTO.Capacity,
                WifiAcces = conferenceRoomDTO.WifiAcces
            };

            context.ConferenceRoom.Add(conferenceRoom);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ConferenceRoomDTO conferenceRoomDTO)
        {
            try
            {
                var room = context.ConferenceRoom.Find(id);

                room.Name = conferenceRoomDTO.Name;
                room.Area = conferenceRoomDTO.Area;
                room.Capacity = conferenceRoomDTO.Capacity;
                room.WifiAcces = conferenceRoomDTO.WifiAcces;

                context.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse(exception.Message));
            }
        }

        // DELETE api/conferenceroom/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var room = context.ConferenceRoom.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            context.ConferenceRoom.Remove(room);

            context.SaveChanges();
            return NoContent();
        }
    }
}