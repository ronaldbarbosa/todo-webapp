using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class TodoTaskListMap : IEntityTypeConfiguration<TodoTaskList>
    {
        public void Configure(EntityTypeBuilder<TodoTaskList> builder)
        {
            builder.Property(t => t.Title)
                .HasColumnType("varchar(20)");

            builder.Property(t => t.Color)
                .HasColumnType("varchar(7)");

            builder.HasMany(t => t.TodoTasks)
                .WithOne(t => t.TodoTaskList)
                .HasForeignKey(t => t.TodoTaskListId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
