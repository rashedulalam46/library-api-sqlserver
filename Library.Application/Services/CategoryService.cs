using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }


    public Task<IEnumerable<Categories>> GetCategoriesAsync()
    {
        return _repo.GetAllAsync();
    }
    public Task<Categories?> GetCategoryAsync(int id)
    {
        return _repo.GetByIdAsync(id);
    }
    public Task<Categories> AddCategoryAsync(Categories category)
    {
        return _repo.AddAsync(category);
    }
    public Task<Categories?> UpdateCategoryAsync(Categories category)
    {
        return _repo.UpdateAsync(category);
    }
    public Task<bool> DeleteCategoryAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }
}