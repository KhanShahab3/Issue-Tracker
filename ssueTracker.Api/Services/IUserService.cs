using IssueTracker.Api.Models;

namespace IssueTracker.Api.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetUsers();
        Task<Users>GetUserById(int id);
        Task<Users> InsertUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(int id);
    }
}
