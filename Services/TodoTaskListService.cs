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

        public async Task<IList<TodoTaskList>> GetTodoTaskListsAsync(string username)
        {
            var lists = await _dbContext.TodoTaskList.Where(u => u.User.UserName == username).ToListAsync();
            return lists;
        }

        public async Task<TodoTaskList> GetTodoTaskListAsync(string username, int? listId)
        {
            var list = await _dbContext.TodoTaskList.Where(u => u.User.UserName == username).FirstAsync(l => l.Id == listId);
            return list;
        }

        public async Task CreateTodoTaskListAsync(string title, string username)
        {
            var user = await _dbContext.User.FirstAsync(u => u.UserName == username);
            var newTodoTaskList = new TodoTaskList()
            {
                Title = title,
                Color = "#FFF000",
                User = user,
                UserId = user.Id,
            };

            await _dbContext.TodoTaskList.AddAsync(newTodoTaskList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
