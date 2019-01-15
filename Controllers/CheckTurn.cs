using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DebateMeAPI.Repository;
using DebateMeAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class CheckTurn : Controller
    {
        private IRoomRepository repoRoom;

        public CheckTurn(IRoomRepository repoRoom)
        {
            this.repoRoom = repoRoom;
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jObject)
        {
            var roomId = Convert.ToInt32(jObject["RoomId"].ToString());
            var userTurnId = repoRoom.UserTurnId(roomId);

            return new JsonResult(userTurnId);
        }
    }
}
