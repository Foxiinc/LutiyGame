using System.Collections.Generic;
using Repositories;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void AddUser(User user, int? referrerId = null)
                {
            if (referrerId.HasValue)
            {
                var referrer = _userRepository.GetUserById(referrerId.Value);
                if (referrer != null)
                {
                    referrer.CountRefs++;
                    _userRepository.UpdateUser(referrer);
                }
            }
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
