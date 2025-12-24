
namespace DotnetC_.Domain.Entities;
public class ErrorResponse
{
    public int StatusCode { get; set; }
    public required string Message { get; set; }
}
