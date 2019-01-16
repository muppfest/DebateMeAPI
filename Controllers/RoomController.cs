using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using DebateMeAPI.Repository;
using DebateMeAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomRepository repoRoom;
        private IUserRepository repoUser;

        public RoomController(IRoomRepository repoRoom, IUserRepository repoUser)
        {
            this.repoRoom = repoRoom;
            this.repoUser = repoUser;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var vm = new List<RoomListViewModel>();
            var rooms = repoRoom.GetAll();

            foreach(var item in rooms)
            {
                var room = new RoomListViewModel();
                room.RoomId = item.RoomId;
                room.Name = repoRoom.GetRoomName(item.RoomId);
                room.PostCount = item.PostCount;
                room.ViewerCount = item.ViewerCount;
                vm.Add(room);
            }

            return new JsonResult(vm);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var room = repoRoom.GetById(id);
            var vm = new RoomViewModel();
            vm.RoomId = id;
            vm.Name = repoRoom.GetRoomName(id);
            vm.PostCount = room.PostCount;
            vm.ViewerCount = room.ViewerCount;
            vm.Category = repoRoom.GetCategory(id);
            vm.Messages = repoRoom.GetMessages(id);
            vm.FirstUser = repoRoom.GetUser(room.FirstUserId);
            vm.SecondUser = repoRoom.GetUser(room.SecondUserId);
            vm.Topic = repoRoom.GetTopic(id);
            vm.FirstUserTurn = repoRoom.IsFirstUserTurn(id);

            return new JsonResult(vm);
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jObject)
        {
            var response = new CreateDebateResponseViewModel();

            var room = new Room();
            room.CategoryId = Convert.ToInt32(jObject["CategoryId"].ToString());
            room.TopicId = Convert.ToInt32(jObject["TopicId"].ToString());
            var email = jObject["Email"].ToString();
            room.FirstUserId = repoUser.GetIdByEmail(email);
            room.FirstUserTurn = true;
            room.PostCount = 0;
            room.ViewerCount = 0;

            response.TopicId = room.TopicId;
            response.CategoryId = room.CategoryId;
            room.RoomId = repoRoom.InsertReturnId(room);
            repoRoom.Save();

            response.Success = true;
            response.Message = "The debate was created successfully!";
            response.RoomId = room.RoomId;

            return new JsonResult(response);
        }
    }
}