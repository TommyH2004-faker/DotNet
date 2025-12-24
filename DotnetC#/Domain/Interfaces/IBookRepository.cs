using DotnetC_.Domain.Entities;

namespace DotnetC_.Domain.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithGenresAsync();
    Task<Book?> GetBookByIdWithDetailsAsync(int id);
}
