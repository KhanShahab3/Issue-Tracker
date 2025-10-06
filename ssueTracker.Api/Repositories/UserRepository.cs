using IssueTracker.Api.DataContext;
using IssueTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IssueTracker.Api.Repositories
{
    public class UserRepository:IUserRepository
    {
        
        private readonly AppDbContext _appDbContext;

        public UserRepository( AppDbContext appDbContext)
        {
            
            _appDbContext = appDbContext;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return users;

        }
        public async Task<Users>GetUserById(int id)
        {
            var user= await _appDbContext.Users.FindAsync(id);
            return user;
        }

        public async Task<Users> CreateUser(Users user)
        {
            try
            {
                var createUser = await _appDbContext.Users.AddAsync(user);
                await _appDbContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                throw; 
            }
        }


        public async Task<Users> UpdateUser(Users user)
        {
            var isUser=await _appDbContext.Users.FindAsync(user.Id);
            if (isUser!=null)
            {
                isUser.Name = user.Name;
                isUser.Email = user.Email;
                isUser.Role = user.Role;
                isUser.Password = user.Password;
            }
            _appDbContext.Update(user);
            await _appDbContext.SaveChangesAsync();
            return user;

        }
        public async Task <bool> DeleteUser(int id)
        {
            var isUser = await _appDbContext.Users.FindAsync(id);
            if (isUser != null)
            {
_appDbContext.Remove(isUser);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            return false;
            
        }
    }
}
