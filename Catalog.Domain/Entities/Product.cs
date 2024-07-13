using Catalog.Domain.Exceptions;

namespace Catalog.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public DateTime RegisterDate { get; private set; }
    
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    
    public Product(string name, string description, decimal price, DateTime registerDate)
    {
        ValidateDomain(name, description, price, registerDate);
    }

    public void Update(string name, string description, decimal price, DateTime registerDate, int categoryId)
    {
        ValidateDomain(name, description, price, registerDate);
        CategoryId = categoryId;
    }
    
    private void ValidateDomain(string name, string description, decimal price, DateTime registerDate)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Name cannot be null or empty.");
        DomainValidationException.When(string.IsNullOrEmpty(description), "Description cannot be null or empty.");
        DomainValidationException.When(price < 0, "Price cannot be negative.");
        DomainValidationException.When(registerDate < DateTime.Now, "Register date cannot be in the future.");

        Name = name;
        Description = description;
        Price = price;
        RegisterDate = registerDate;
    }
}