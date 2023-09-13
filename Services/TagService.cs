using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services
{
    public class TagService
    {
        private readonly TodoListDbContext _dbContext;

        public TagService(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Tag>> GetTagsAsync()
        {
            return await _dbContext.Tag.ToListAsync();
        }

        public async Task CreateTagAsync(Tag tag)
        {
            await _dbContext.Tag.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}
