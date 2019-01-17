using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DebateMeAPI.Repository;
using DebateMeAPI.Models;
using DebateMeAPI.ViewModels;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckTurnController : ControllerBase
    {
        private IRoomRepository repoRoom;
        private IUserRepository repoUser;

        public CheckTurnController(IRoomRepository repoRoom, IUserRepository repoUser)
        {
            this.repoRoom = repoRoom;
            this.repoUser = repoUser;
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jObject)
        {
            var response = new CheckTurnResponseViewModel();
            response.Success = false;
            response.Message = "It's not your turn!";

            var roomId = Convert.ToInt32(jObject["RoomId"].ToString());
            var userId = Convert.ToInt32(jObject["UserId"].ToString());

            if (repoRoom.UserTurnId(roomId) == userId)
            {
                response.Success = true;
                response.Message = "It's your turn!";
            }

            return new JsonResult(response);
        }
    }
}
