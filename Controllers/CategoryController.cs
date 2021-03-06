using Day11.Data.Repositories;
using Day11.Models;
using Day11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day11.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    // private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _repository;

    public CategoryController(ILogger<CategoryController> logger, 
    // ICategoryService categoryService
    ICategoryRepository repository)
    {
        _logger = logger;
        // _categoryService = categoryService;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await _repository.GetAllIncludedAsync();
        var results = from item in entities
                      select new CategoryViewModel
                      {
                        Id = item.Id,
                        Name = item.Name,
                        Products = from p in item.Products
                                    select new ProductViewModel
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Manufacture = p.Manufacture
                                    }
                      };
        return new JsonResult(results);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOneAsync(int id)
    {
        throw new NotImplementedException();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CategoryCreateModel model)
    {
        try
        {
            var entity = new Data.Entities.Category
            {
                Name = model.Name,
                Products = (from p in model.Products
                            select new Data.Entities.Product
                            {
                                Name = p.Name,
                                Manufacture = p.Manufacture
                            }).ToList()
            };
            var result = await _repository.InsertAsync(entity);
            return new JsonResult(new CategoryViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = from p in entity .Products
                                    select new ProductViewModel
                                    {
                                        Id = p.Id,
                                        Name = p.Name,
                                        Manufacture = p.Manufacture
                                    }
            });
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id,StudentCreateModel model)
    {
       throw new NotImplementedException();
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
       throw new NotImplementedException();
    }
}
