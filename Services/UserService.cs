using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Models.ViewModels;

namespace TodoList.Services
{
    public class UserService
    {
        private readonly TodoListDbContext _dbContext;

        public UserService(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == username);
            return user;
        }

        public async Task<string> GetUserIdAsync(string username)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == username);
            return user.Id;
        }

        public async Task EditUserAsync(EditUserViewModel viewModel, string username)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.UserName == username);
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
