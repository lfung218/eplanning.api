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
    public class UsersController : Controller
    {

        private readonly EplanningContext db;

        public UsersController(EplanningContext db) 
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Users);
        }


        // GET api/values/5
        [HttpGet("{id}", Name="GetUser")]
        public IActionResult GetById(int id)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = user.Id}, user);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User newUser)
        {
            if (newUser == null || newUser.Id != id)
            {
                return BadRequest();
            }
            var currentUser = this.db.Users.FirstOrDefault(x => x.Id == id);

            if (currentUser == null)
            {
                return NotFound();
            }
            
            currentUser.FirstName = newUser.FirstName;
            currentUser.LastName = newUser.LastName;
            currentUser.Gender = newUser.Gender;
            currentUser.BDay = newUser.BDay;
            currentUser.EventNames = newUser.EventNames;

            


            this.db.Users.Update(currentUser);
            this.db.SaveChanges();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();
            return NoContent();
        }
    }
}
