var shoppingCart = new List<Product>
{
    new Product("Reusable water bottle", 12.99m),
    
    // A Book can be used as a Product and stored in the general cart.
    new Book("The Pragmatic Programmer", 42.50m, "David Thomas and Andrew Hunt", "978-0135957059")
};

PrintReceipt(shoppingCart); // PrintReceipt accepts Product items, but works with the Book without special handling.

var booksOnlyCart = new List<Book>
{
    new Book("Clean Code", 39.99m, "Robert C. Martin", "978-0132350884")

    // This insertion does not compile: a List<Book> only accepts Book objects.
    // We can't substitute Book with Product, even though Book is a subclass of Product.
    //new Product("Reusable shopping bag", 2.99m);
};

Console.WriteLine($"Books-only cart contains {booksOnlyCart.Count} book(s).");

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
