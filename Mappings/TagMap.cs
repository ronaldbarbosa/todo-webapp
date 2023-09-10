using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Title)
                .HasColumnType("varchar(20)");

            builder.HasData(
                new Tag(1, "Study"),
                new Tag(2, "Work")
            );
        }
    }
}
