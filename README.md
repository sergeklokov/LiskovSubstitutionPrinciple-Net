# Liskov Substitution Principle: Online Shop Example

This .NET 10 console app demonstrates the Liskov Substitution Principle (LSP) with a shop's `Product` type and its specialized `Book` subtype.

## Where substitution happens

In `LiskovSubstitutionPrinciple-Net/Program.cs`:

1. The `shoppingCart` collection is declared as `List<Product>`, then a `Book` instance is added. A `Book` is usable as a `Product` because it inherits from `Product`.
2. `shoppingCart` is passed to `PrintReceipt`, whose parameter is `IEnumerable<Product>`. The receipt function does not need a separate book-specific path.
3. The loop processes each entry as a `Product`. For the book, reading the shared `Price` property works as for any product, while calling `GetDescription()` dispatches to `Book.GetDescription()` and includes the book details.

The `Book` therefore preserves the behavior expected by code working with `Product`, while adding its own author and ISBN information. This substitutability—not merely the inheritance declaration—is the LSP demonstration.

## Run

Run the `LiskovSubstitutionPrinciple-Net` project. The output shows both cart items and their total.
