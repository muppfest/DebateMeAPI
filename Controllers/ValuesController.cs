using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            User[] users = new User[]
            {
                new User()
                {
                    UserId = 1,
                    FirstName = "Test",
                    LastName = "Testsson"
                },

                new User()
                {
                    UserId = 2,
                    FirstName = "Anton",
                    LastName = "Nummer Ett"
                },

                new User()
                {
                    UserId = 3,
                    FirstName = "Anton",
                    LastName = "Nummer Två"
                }
            };

            return users;
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
