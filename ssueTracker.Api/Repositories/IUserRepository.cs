using IssueTracker.Api.Models;

namespace IssueTracker.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool>DeleteUser(int id);
    }
}
