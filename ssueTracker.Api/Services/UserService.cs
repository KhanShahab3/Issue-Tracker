using IssueTracker.Api.Models;
using IssueTracker.Api.Repositories;

namespace IssueTracker.Api.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Users>> GetUsers()
        {
            var users=await _userRepository.GetAllUsers();
            if (users.Count == 0)
            {
                return new List<Users>();
            }
            return users;
        }

        public async Task<Users> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;

            }
            else
            {
                return user;
            }
        }
        public async Task<Users> InsertUser(Users user)
        {
            var createdUser = await _userRepository.CreateUser(user);
            if (createdUser == null)
            {
                return null;
            }
            return user;
        }
        public async Task<Users> UpdateUser(Users user)
        {
            var updatedUser = await _userRepository.UpdateUser(user);
            if (updatedUser == null)
            {
                return null;

            }
            return updatedUser;

        }
        public async Task<bool> DeleteUser(int id)
        {
            var isUser = await _userRepository.DeleteUser(id);
            if (!isUser)
            {
                return false;
            }
            return true;
        }
    }
}
