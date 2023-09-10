using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class TodoTaskMap : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(t => t.Title)
                .HasColumnType("varchar(20)");
            
            builder.Property(t => t.Description)
                .HasColumnType("varchar(100)");


            builder.HasMany(t => t.Tags)
                .WithMany(t => t.TodoTasks)
                .UsingEntity(e => e.ToTable("TodoTaskTag"));


            builder.HasData(
                new TodoTask(
                    1,
                    "Study",
                    "Study AspNet Core MVC all weekend",
                    "50d0af67-12f6-4c63-90e0-7981b9538893"
                )
            );
        }
    }
}
