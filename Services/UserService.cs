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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        { 
            return await _dbContext.Users.ToListAsync();
        }

        public async Task CreateUserAsync(UserFormViewModel userForm)
        {
            var newUser = new User() { FirstName = userForm.FirstName, LastName = userForm.LastName };
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(UserFormViewModel userForm)
        {
            var user = await _dbContext.Users.FindAsync(userForm.Id);
            user.FirstName = userForm.FirstName;
            user.LastName = userForm.LastName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _dbContext.Users.Include(obj => obj.TodoTasks).FirstOrDefaultAsync(obj => obj.Id == id);
            if (user.TodoTasks.Count < 1)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
