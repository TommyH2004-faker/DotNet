using DotnetC_.Application.Books.Commands;
using Microsoft.AspNetCore.Mvc;
namespace DotnetC_.Presentation.Controllers;
[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly CreateBookHandler _handler;

    public BookController(CreateBookHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        await _handler.Handle(command);
        return Ok();
    }
}
