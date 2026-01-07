using BlogWebsite.Models;

namespace BlogWebsite.Repositary.CategoryRepositary
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category Category);
        Task UpdateAsync(Category Category);
        Task DeleteAsync(int id);
    }
}
