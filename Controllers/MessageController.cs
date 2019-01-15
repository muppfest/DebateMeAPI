using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using DebateMeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DebateMeAPI.ViewModels;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IRepository<Message> repoMessage;
        private IUserRepository repoUser;
        private IRepository<Room> repoRoom;

        public MessageController(IRepository<Message> repoMessage, IUserRepository repoUser, IRepository<Room> repoRoom)
        {
            this.repoMessage = repoMessage;
            this.repoUser = repoUser;
        }

        [HttpGet("{RoomId}")]
        public JsonResult Get(int roomId)
        {
            var messages = repoMessage.GetAll().Where(w => w.RoomId == roomId).ToList();
            return new JsonResult(messages);
        }

        [HttpPost]
        public void Post([FromBody]JObject jObject)
        {
            var response = new MessageResponseViewModel();
            response.Success = false;
            response.Message = "Message did not post.";

            var token = jObject["Token"].ToString();
            var roomId = jObject["RoomId"].ToString();
            var text = jObject["Text"].ToString();
            var userId = Convert.ToInt32(jObject["UserId"].ToString());

            var email = repoUser.GetEmailById(userId);
            if(token.Equals(NETCore.Encrypt.EncryptProvider.Sha512(email)))
            {

            }
        }
    }
}