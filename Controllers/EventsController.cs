using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eplanning.api.Data;
using eplanning.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace eplanning.api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {

        private readonly EplanningContext db;

        public EventsController(EplanningContext db) 
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Events);
        }


        // GET api/values/5
        [HttpGet("{id}", Name="GetEvent")]
        public IActionResult GetById(int id)
        {
            var evnt = db.Events.Find(id);

            if (evnt == null)
            {
                return NotFound();
            }

            return Ok(evnt);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Event evnt)
        {
            if(evnt == null)
            {
                return BadRequest();
            }
            db.Events.Add(evnt);
            db.SaveChanges();

            return CreatedAtRoute("GetEvent", new { id = evnt.Id}, evnt);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event newEvent)
        {
            if (newEvent == null || newEvent.Id != id)
            {
                return BadRequest();
            }
            var currentEvent = this.db.Events.FirstOrDefault(x => x.Id == id);

            if (currentEvent == null)
            {
                return NotFound();
            }

            currentEvent.Name = newEvent.Name;
            currentEvent.Description = newEvent.Description;
            currentEvent.Location = newEvent.Location;
            currentEvent.Creator = newEvent.Creator;
            currentEvent.EventDate = newEvent.EventDate;
            currentEvent.EventType = newEvent.EventType;
            currentEvent.NumOfGuest = newEvent.NumOfGuest;

            this.db.Events.Update(currentEvent);
            this.db.SaveChanges();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evnt = this.db.Events.FirstOrDefault(x => x.Id == id);

            if (evnt == null)
            {
                return NotFound();
            }

            db.Events.Remove(evnt);
            db.SaveChanges();
            return NoContent();
        }
    }
}
