using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasColumnType("varchar(15)");

            builder.Property(u => u.LastName)
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Email)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.Password)
                .HasColumnType("varchar(256)");


            builder.HasMany(u => u.UserTodoTasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.TodoTaskLists)
                .WithOne(t => t.User) 
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
