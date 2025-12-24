namespace DotnetC_.Domain.Exceptions;

public class BadRequestException : AppException
{
    public BadRequestException(string message) : base(message) { }
}
