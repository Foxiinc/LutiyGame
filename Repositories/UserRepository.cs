using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
private readonly ApplicationContext _context;

public UserRepository(ApplicationContext context)
        {
    _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Set<User>().Find(id);
        }

        public void AddUser(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Set<User>().Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Set<User>().Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Set<User>().ToList();
        }
    }
}
