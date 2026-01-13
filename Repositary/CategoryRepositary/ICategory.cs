using System.Linq.Expressions;
using BlogWebsite.Models;

namespace BlogWebsite.Repositary.CategoryRepositary
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategories(Expression<Func<Category, bool>>? filter = null);
    
      
    }
}
