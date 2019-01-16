using DebateMeAPI.Models;
using DebateMeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateMeAPI.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        int InsertReturnId(Room room);
        string GetRoomName(int id);
        UserViewModel GetUser(int userId);
        TopicViewModel GetTopic(int id);
        CategoryViewModel GetCategory(int id);
        List<MessageViewModel> GetMessages(int id);
        bool IsFirstUser(int userId);
        bool IsFirstUserTurn(int id);
        string GetUserName(int userId);
        int UserTurnId(int roomId);
    }
}
