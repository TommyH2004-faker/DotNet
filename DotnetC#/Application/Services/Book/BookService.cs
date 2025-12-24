

using AutoMapper;
using DotnetC_.Application.DTOs.DtoBook;
using DotnetC_.Application.Interfaces;
using DotnetC_.Domain.Entities;
using DotnetC_.Domain.Exceptions;
using DotnetC_.Domain.Interfaces;

namespace DotnetC_.Application.Services;

 public class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepo;
    private readonly IMapper _mapper;

    public BookService(IRepository<Book> bookRepo, IMapper mapper)
    {
        _bookRepo = bookRepo;
        _mapper = mapper;
    }

    public async Task<Book> CreateBookAsync(CreateBookDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        await _bookRepo.AddAsync(book);
        return _mapper.Map<Book>(book);
    }


    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books =  _bookRepo.GetAllAsync();
        await Task.CompletedTask;
        return _mapper.Map<List<Book>>(books);
    }

     public async Task DeleteBook(int id)
    {
        var book = await _bookRepo.GetByIdAsync(id);
        if (book == null) throw new NotFoundException("Book not found");
        await _bookRepo.DeleteAsync(book);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        var books = await _bookRepo.GetAllAsync();
        return _mapper.Map<List<Book>>(books);
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var book =  _bookRepo.GetByIdAsync(id);
        if(book == null)
        {
            throw new NotFoundException($"Book with id {id} not found");
        }
        await Task.CompletedTask;
        return _mapper.Map<Book>(book);
    }

    public async Task<Book> UpdateBookAsync(int id, Book book)
    {
        var updatedBook =  _bookRepo.UpdateAsync(book);
        if(updatedBook == null)
        {
            throw new NotFoundException($"Book with id {id} not found");
        }
        await Task.CompletedTask;
        return _mapper.Map<Book>(updatedBook);
    }
}