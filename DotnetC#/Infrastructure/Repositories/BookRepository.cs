using DotnetC_.Domain.Entities;
using DotnetC_.Domain.Exceptions;
using DotnetC_.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotnetC_.Infrastructure.Repositories;
public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllAsync()
        => await _context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(Guid id)
        => await _context.Books.FindAsync(id);

    public async Task UpdateAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
