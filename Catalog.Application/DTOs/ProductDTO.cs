using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.DTOs;

public class ProductDTO
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
    
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 9999.00, ErrorMessage = "Price must be between 0.01 and 9999.00")]
    public decimal Price { get; set; }
}