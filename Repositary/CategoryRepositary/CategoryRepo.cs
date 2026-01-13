using System.Linq.Expressions;
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

        public async Task<IEnumerable<Category>> GetAllCategories(Expression<Func<Category, bool>>? filter = null)
        {
            var query = _Db.Categories.AsQueryable();
            if(filter != null)
            {
                query = query.Where(filter);

            }
            return await query.ToListAsync();
        }

    }
}
