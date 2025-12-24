using DotnetC_.Domain.Entities;
using DotnetC_.Application.DTOs.DtoBook;
using DotnetC_.Application.Interfaces;
using DotnetC_.Domain.Interfaces;
using DotnetC_.Domain.Exceptions;

namespace DotnetC_.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Book> CreateBookAsync(CreateBookDto createBookDto)
    {
        var book = new Book
        {
            NameBook = createBookDto.NameBook,
            Author = createBookDto.Author,
            Isbn = createBookDto.Isbn,
            Description = createBookDto.Description,
            ListPrice = createBookDto.ListPrice,
            SellPrice = createBookDto.SellPrice,
            Quantity = createBookDto.Quantity,
            DiscountPercent = createBookDto.DiscountPercent
        };

        return await _bookRepository.AddAsync(book);
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetBooksWithGenresAsync();
        return books.ToList();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdWithDetailsAsync(id);
        if (book == null)
        {
            throw new NotFoundException($"Book with id {id} not found");
        }
        return book;
    }

    public async Task<Book> UpdateBookAsync(int id, Book book)
    {
        var existingBook = await _bookRepository.GetByIdAsync(id);
        if (existingBook == null)
        {
            throw new NotFoundException($"Book with id {id} not found");
        }
        
        await _bookRepository.UpdateAsync(book);
        return book;
    }
}