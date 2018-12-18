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
    public class RoomController : ControllerBase
    {
        private IRepository<Room> repoRoom;

        public RoomController(IRepository<Room> repoRoom)
        {
            this.repoRoom = repoRoom;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> Get()
        {
            return repoRoom.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            return repoRoom.GetById(id);
        }
    }
}