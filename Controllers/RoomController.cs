using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using DebateMeAPI.Repository;
using DebateMeAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomRepository<Room> repoRoom;

        public RoomController(IRoomRepository<Room> repoRoom)
        {
            this.repoRoom = repoRoom;
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
    }
}