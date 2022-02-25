using Day11.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Day11.Data.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IEnumerable<Category>> GetAllIncludedAsync();
}
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> GetAllIncludedAsync()
    {
        return await _entities.Include(c => c.Products).ToListAsync();

    }
}