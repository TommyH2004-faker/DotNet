namespace DotnetC_.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    protected Book() { } // EF Core

    public Book(string title, string author, decimal price, int quantity)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Price = price;
        Quantity = quantity;
    }

    public void UpdateInfo(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public void DecreaseStock(int amount)
    {
        if (amount > Quantity)
            throw new Exception("Not enough stock");

        Quantity -= amount;
    }
}
