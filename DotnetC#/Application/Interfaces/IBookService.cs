using DotnetC_.Application.DTOs.DtoBook;
using DotnetC_.Domain.Entities;

namespace DotnetC_.Application.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(CreateBookDto dto);
    Task<Book> UpdateBookAsync(int id, Book book);
}
