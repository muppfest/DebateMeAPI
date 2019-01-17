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
        private IRoomRepository repoRoom;

        public MessageController(IRepository<Message> repoMessage, IUserRepository repoUser, IRoomRepository repoRoom)
        {
            this.repoMessage = repoMessage;
            this.repoUser = repoUser;
            this.repoRoom = repoRoom;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var messages = repoMessage.GetAll();
            return new JsonResult(messages);
        }

        [HttpGet("{RoomId}")]
        public JsonResult Get(int roomId)
        {
            var messages = repoMessage.GetAll().Where(w => w.RoomId == roomId).ToList();
            return new JsonResult(messages);
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jObject)
        {
            var response = new MessageResponseViewModel();
            response.Success = false;
            response.Message = "Message is not sent!";

            var token = jObject["Token"].ToString();
            var roomId = Convert.ToInt32(jObject["RoomId"].ToString());
            var userId = Convert.ToInt32(jObject["UserId"].ToString());
            var text = jObject["Text"].ToString();
            var email = repoUser.GetEmailById(userId);

            if(token.Equals(NETCore.Encrypt.EncryptProvider.Sha512(email)))
            {
                var message = new Message();
                message.UserId = userId;
                message.RoomId = roomId;
                message.Text = text;

                repoMessage.Insert(message);
                repoMessage.Save();

                response.Success = true;
                response.Message = "Message is sent!";

                repoRoom.ChangeTurnAfterPost(roomId);
            }

            return new JsonResult(response);
        }
    }
}