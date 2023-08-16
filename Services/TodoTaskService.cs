using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Models.ViewModels;

namespace TodoList.Services
{
    public class TodoTaskService
    {
        private readonly TodoListDbContext _dbContext;

        public TodoTaskService(TodoListDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTodoTask(TodoTask todoTask)
        {
            await _dbContext.TodoTasks.AddAsync(todoTask);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasks()
        {
            var todoTasks = await _dbContext.TodoTasks.Include(obj => obj.User).ToListAsync();
            return todoTasks.OrderBy(obj => obj.Finished).ToList();
        }

        public async Task<TodoTask> GetTodoTaskById(Guid id)
        {
            return await _dbContext.TodoTasks.Include(obj => obj.User).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task DeleteTodoTask(Guid id)
        {
            var todoTask = await _dbContext.TodoTasks.FindAsync(id);
            if (todoTask != null) 
            {
                _dbContext.TodoTasks.Remove(todoTask);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTodoTask(TodoTaskFormViewModel todoTaskForm)
        {
            var todoTask = await _dbContext.TodoTasks.FindAsync(todoTaskForm.Id);
            if (todoTask != null) 
            {
                todoTask.Title = todoTaskForm.Title;
                todoTask.Description = todoTaskForm.Description;
                todoTask.UpdatedDate = DateTime.Now;
                _dbContext.TodoTasks.Update(todoTask);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTodoTaskStatus(Guid id, bool status)
        {
            var todoTask = await GetTodoTaskById(id);
            if (todoTask != null) 
            {
                todoTask.UpdatedDate = DateTime.Now;
                todoTask.Finished = status;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
