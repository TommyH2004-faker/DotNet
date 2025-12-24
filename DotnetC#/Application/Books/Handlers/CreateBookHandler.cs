using DotnetC_.Application.Books.Commands;
using DotnetC_.Domain.Entities;

public class CreateBookHandler
{
    private readonly DotnetC_.Domain.Exceptions.IBookRepository _repo;

    public CreateBookHandler(DotnetC_.Domain.Exceptions.IBookRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(CreateBookCommand cmd)
    {
        var book = new Book(
            cmd.Title,
            cmd.Author,
            cmd.Price,
            cmd.Quantity
        );

        await _repo.AddAsync(book);
    }
}
