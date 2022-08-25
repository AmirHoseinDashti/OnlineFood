using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Online_food.Models;

namespace Online_food.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByPhone(string phone);
        void AddUser(Users user);
        Users GetUsersForLogin(string phone, string password);
    }

    public class UserRepository : IUserRepository
    {
        private OnlineFoodContext _context;

        public UserRepository(OnlineFoodContext context)
        {
            _context = context;
        }
        public bool IsExistUserByPhone(string phone)
        {
            return _context.Users.Any(u => u.Phone == phone);
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public Users GetUsersForLogin(string phone, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Phone == phone && u.Password == password);
        }
    }
}
