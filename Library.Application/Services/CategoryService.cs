using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services;

public class CategoryService 
{
    private readonly ICategoryRepository _repo;
    public CategoryService(ICategoryRepository repo) => _repo = repo;

    public Task<IEnumerable<Categories>> GetCategoriesAsync() => _repo.GetAllAsync();
    public Task<Categories?> GetCategoryAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Categories> AddCategoryAsync(Categories category) => _repo.AddAsync(category);
    public Task<Categories?> UpdateCategoryAsync(Categories category) => _repo.UpdateAsync(category);
    public Task<bool> DeleteCategoryAsync(int id) => _repo.DeleteAsync(id);
}