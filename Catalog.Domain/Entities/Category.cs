using Catalog.Domain.Exceptions;

namespace Catalog.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public ICollection<Product> Products { get; set; }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
        ValidateDomain(name, description);
    }
    
    public Category(string name, string description, int id)
    {
        Name = name;
        Description = description;
        Id = id;
        ValidateDomain(name, description);
    }

    private void ValidateDomain(string name, string description)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name cannot be null or empty.");
        DomainValidationException.When(name.Length < 3, "Name must be at least 3 characters.");
        DomainValidationException.When(string.IsNullOrEmpty(description), "Description cannot be null or empty.");
    }
}