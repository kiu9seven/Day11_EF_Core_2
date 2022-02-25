using Day11.Data;
using Day11.Data.Entities;
using Day11.Data.Repositories;

namespace Day11.Services;


public interface ICategoryService
{
    public Task<IList<Category>> GetAllAsync();
    public Task<Category?> GetOneAsync(int id);
    public Task<Category?> AddAsync(Category entity);
    public Task<Category?> EditAsync(Category entity);
    public Task RemoveAsync(int id);

}
public class CategoryService: ICategoryService
{
    private readonly CategoryRepository _repository;
    public CategoryService(CategoryRepository repository)
    {
        _repository = repository;
    }

    public Task<Category?> AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> EditAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        // await _repository.FilterAsync();
        var data = await _repository.GetAllIncludedAsync();
        return data.ToList();
    }

    public Task<Category?> GetOneAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}