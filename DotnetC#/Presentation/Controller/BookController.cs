using Microsoft.AspNetCore.Mvc;
using DotnetC_.Application.Interfaces;
using DotnetC_.Domain.Entities;
using DotnetC_.Application.DTOs.DtoBook;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return Ok(book);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto createBookDto)
    {
        var createdBook = await _bookService.CreateBookAsync(createBookDto);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.IdBook }, createdBook);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
    {
        var updatedBook = await _bookService.UpdateBookAsync(id, book);
        return Ok(updatedBook);
    }
}