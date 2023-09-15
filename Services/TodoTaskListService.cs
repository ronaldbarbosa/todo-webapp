using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoTaskListService
    {
        private readonly TodoListDbContext _dbContext;

        public TodoTaskListService(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TodoTaskList>> GetTodoTaskListAsync(string username)
        {
            var lists = await _dbContext.TodoTaskList.Where(u => u.User.UserName == username).ToListAsync();
            return lists;
        }
    }
}
