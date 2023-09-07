using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<TodoTask> TodoTask { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TodoTaskList> TodoTaskList { get; set; }
    }
}
