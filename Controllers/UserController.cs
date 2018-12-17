using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using DebateMeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<User> repoUser;

        public UserController(IRepository<User> repoUser)
        {
            this.repoUser = repoUser;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return repoUser.GetAll();
        }
    }
}