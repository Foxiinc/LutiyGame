using System.Collections.Generic;

namespace Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        IEnumerable<User> GetAllUsers();
    }
}
