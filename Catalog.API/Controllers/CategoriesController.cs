using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllAsync()
    {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        
        if (category == null) return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostAsync(CategoryDTO entity)
    {
        await _categoryService.AddAsync(entity);
        return Created();
    }

    [HttpPut]
    public async Task<ActionResult<CategoryDTO>> PutAsync(CategoryDTO entity)
    {
        await _categoryService.UpdateAsync(entity);
        return Ok(entity);
    }

    [HttpDelete]
    public async Task<ActionResult<CategoryDTO>> DeleteAsync(CategoryDTO entity)
    {
        await _categoryService.RemoveAsync(entity);
        return NoContent();
    }
}