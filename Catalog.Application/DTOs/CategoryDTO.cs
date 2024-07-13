using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
    [MaxLength(24, ErrorMessage = "Name must be between 3 and 24 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [MinLength(8, ErrorMessage = "Description must be at least 8 characters")]
    [MaxLength(128, ErrorMessage = "Description must be between 8 and 128 characters")]
    public string Description { get; set; }
}