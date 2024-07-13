using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CategoryService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var categories =  await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetByIdAsync(int id)
    {
        var category = await _productRepository.GetEntityByIdAsync(id);
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task AddAsync(CategoryDTO entity)
    {
        var category = _mapper.Map<Product>(entity);
        await _productRepository.CreateAsync(category);
    }

    public async Task UpdateAsync(CategoryDTO entity)
    {
        var category = _mapper.Map<Product>(entity);
        await _productRepository.UpdateAsync(category);
    }

    public async Task RemoveAsync(CategoryDTO entity)
    {
        var category = _mapper.Map<Product>(entity);
        await _productRepository.RemoveAsync(category);
    }
}