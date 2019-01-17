using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Repository;
using DebateMeAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinDebateController : ControllerBase
    {
        private IRoomRepository repoRoom;
        private IUserRepository repoUser;

        public JoinDebateController(IRoomRepository repoRoom, IUserRepository repoUser)
        {
            this.repoRoom = repoRoom;
            this.repoUser = repoUser;
        }

        [HttpPost]
        public JsonResult Post([FromBody] JObject jObject)
        {
            var response = new JoinDebateResponseViewModel();
            response.Success = false;
            response.Message = "Could not join the debate.";

            var userId = Convert.ToInt32(jObject["UserId"].ToString());
            var roomId = Convert.ToInt32(jObject["RoomId"].ToString());
            var token = jObject["Token"].ToString();
            var email = repoUser.GetEmailById(userId);

            if (repoRoom.JoinDebate(roomId, userId) && token.Equals(NETCore.Encrypt.EncryptProvider.Sha512(email)))
            {   
                response.Success = true;
                response.Message = "You have successfully joined the debate!";
                
            }
            return new JsonResult(response);
        }
    }
}