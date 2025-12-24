using DotnetC_.Domain.Entities;
using DotnetC_.Domain.Interfaces;
using DotnetC_.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetC_.Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetBooksWithGenresAsync()
    {
        return await _dbSet
            .Include(b => b.Genres)
            .Include(b => b.Images)
            .ToListAsync();
    }

    public async Task<Book?> GetBookByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(b => b.Genres)
            .Include(b => b.Images)
            .Include(b => b.Reviews)
            .FirstOrDefaultAsync(b => b.IdBook == id);
    }
}
