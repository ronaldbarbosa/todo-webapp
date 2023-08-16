using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using TodoList.Models.ViewModels;

namespace TodoList.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TodoTask> TodoTasks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
