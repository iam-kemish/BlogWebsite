using BlogWebsite.Database;
using BlogWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Repositary.CategoryRepositary
{
    public class CategoryRepo : ICategory
    {
        private readonly AppDbContext _Db;
        public CategoryRepo(AppDbContext appDbContext)
        {
            _Db = appDbContext;
        }
        public async Task AddAsync(Category Category)
        {
            _Db.Categories.Add(Category);
            await _Db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _Db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (category != null)
            {
                _Db.Categories.Remove(category);
                await _Db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _Db.Categories
                .Include(p => p.Posts)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var post = await _Db.Categories.Include(p => p.Posts).FirstOrDefaultAsync(p => p.Id == id);
            return post;
        }

        public async Task UpdateAsync(Category Category)
        {
            var existingCategory = await _Db.Categories.FirstOrDefaultAsync(u => u.Id == Category.Id);
            if (existingCategory == null)
            {
                return;
            }
            existingCategory.Description = Category.Description;
            existingCategory.Name = Category.Name;
            await _Db.SaveChangesAsync();

        }
    }
}
