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
    public class MessageController : ControllerBase
    {
        private IRepository<Message> repoMessage;

        public MessageController(IRepository<Message> repoMessage)
        {
            this.repoMessage = repoMessage;
        }

        [HttpGet("{RoomId}")]
        public ActionResult<IEnumerable<Message>> Get(int roomId)
        {
            var messages = repoMessage.GetAll().Where(w => w.RoomId == roomId).ToList();
            return messages;
        }
    }
}