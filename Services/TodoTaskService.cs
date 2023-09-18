using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoTaskService
    {
        private readonly TodoListDbContext _dbContext;

        public TodoTaskService(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TodoTask>> GetTodoTasksAsync(string username)
        {
            var tasks = await _dbContext.TodoTask.Where(u => u.User.UserName == username).Include(t => t.TodoTaskList).ToListAsync();
            return tasks;
        }

        public async Task CreateTodoTaskAsync(TodoTask todoTask)
        {
            await _dbContext.TodoTask.AddAsync(todoTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TodoTask> GetTodoTaskAsync(int id)
        {
            var todoTask = await _dbContext.TodoTask.Include(t => t.TodoTaskList).FirstAsync(t => t.Id == id);
            return todoTask;
        }

        public async Task UpdateTodoTaskAsync(TodoTask todoTask)
        {
            _dbContext.TodoTask.Update(todoTask);
            await _dbContext.SaveChangesAsync();
        }
    }
}
