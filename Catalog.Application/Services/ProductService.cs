using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetEntityByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task AddAsync(ProductDTO entity)
    {
        var product = _mapper.Map<Product>(entity);
        await _productRepository.CreateAsync(product);
    }

    public async Task UpdateAsync(ProductDTO entity)
    {
        var product = _mapper.Map<Product>(entity);
        await _productRepository.UpdateAsync(product);
    }

    public Task RemoveAsync(ProductDTO entity)
    {
        var product = _mapper.Map<Product>(entity);
        return _productRepository.RemoveAsync(product);
    }
}