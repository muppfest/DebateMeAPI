using DebateMeAPI.Models;
using DebateMeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly DebateMeContext _db;

        public RoomRepository(DebateMeContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public CategoryViewModel GetCategory(int id)
        {
            var categoryId = _db.Set<Room>().Find(id).CategoryId;
            var category = _db.Set<Category>().Where(w => w.CategoryId == categoryId).SingleOrDefault();
            var vm = new CategoryViewModel();
            vm.Name = category.Name;
            vm.CategoryId = category.CategoryId;
            return vm;
        }

        public List<MessageViewModel> GetMessages(int id)
        {
            var messages = _db.Set<Message>().Where(w => w.RoomId == id).ToList();
            var vm = new List<MessageViewModel>();
            
            foreach(var item in messages)
            {
                var message = new MessageViewModel();
                message.MessageId = item.MessageId;
                message.Text = item.Text;
                message.IsFirstPlayer = IsFirstUser(item.UserId);
                message.Name = GetUserName(item.UserId);
                vm.Add(message);
            }

            return vm;
        }

        public string GetRoomName(int id)
        {
            return GetCategory(id).Name + " - " + GetTopic(id).Name + " #" + id;
        }

        public UserViewModel GetUser(int userId)
        {
            var user = _db.Set<User>().Where(w => w.UserId == userId).SingleOrDefault();
            var vm = new UserViewModel();
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.UserId = user.UserId;

            return vm;
        }

        public TopicViewModel GetTopic(int id)
        {
            var topicId = _db.Set<Room>().Find(id).TopicId;
            var topic = _db.Set<Topic>().Where(w => w.TopicId == topicId).SingleOrDefault();
            var vm = new TopicViewModel();
            vm.Name = topic.Name;
            vm.TopicId = topic.TopicId;

            return vm;
        }

        public bool IsFirstUser(int userId)
        {
            if(_db.Set<Room>().Select(s => s.FirstUserId).SingleOrDefault() == userId)
            {
                return true;
            }

            return false;
        }

        public string GetUserName(int userId)
        {
            var user = GetUser(userId);
            return user.FirstName + " " + user.LastName;
        }

        public bool IsFirstUserTurn(int id)
        {
            var room = _db.Set<Room>().Find(id);
            var lastMessage = _db.Set<Message>().Where(w => w.RoomId == id).LastOrDefault();
            var firstPlayerId = room.FirstUserId;

            if(lastMessage.UserId != firstPlayerId)
            {
                return true;
            }

            return false;
        }

        public int UserTurnId(int roomId)
        {
            var room = _db.Set<Room>().Find(roomId);
            var userId = new int();

            if (room.FirstUserTurn)
            {
                userId = room.FirstUserId;
            } else
            {
                userId = room.SecondUserId;
            }
            return userId;
        }

        public int InsertReturnId(Room room)
        {
            _db.Set<Room>().Add(room);
            _db.SaveChanges();

            return room.RoomId;
        }
    }
}
