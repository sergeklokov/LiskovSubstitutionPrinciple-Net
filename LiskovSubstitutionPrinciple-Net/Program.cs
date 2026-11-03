var shoppingCart = new List<Product>
{
    new Product("Reusable water bottle", 12.99m),
    
    // A Book is substituted for Product here and can be stored in the same cart.
    new Book("The Pragmatic Programmer", 42.50m, "David Thomas and Andrew Hunt", "978-0135957059")
};

// PrintReceipt accepts Product items, but works with the Book in this cart without special handling.
PrintReceipt(shoppingCart);

static void PrintReceipt(IEnumerable<Product> products)
{
    decimal total = 0;

    Console.WriteLine("Shopping cart");
    foreach (var product in products)
    {
        // product is treated as a Product; virtual dispatch calls Book.GetDescription() for a Book.
        Console.WriteLine($"- {product.GetDescription()}: {product.Price:C}");
        total += product.Price;
    }

    Console.WriteLine($"Total: {total:C}");
}

public class Product
{
    public Product(string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(price);

        Name = name;
        Price = price;
    }

    public string Name { get; }
    public decimal Price { get; }

    public virtual string GetDescription() => Name;
}

public sealed class Book(string name, decimal price, string author, string isbn) : Product(name, price)
{
    public string Author { get; } = author;
    public string Isbn { get; } = isbn;

    public override string GetDescription() => $"{Name} by {Author} (ISBN: {Isbn})";
}
