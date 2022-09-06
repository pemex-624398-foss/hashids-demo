namespace Pemex.Foss.HashidsDemo.Api.Core.Model;

public class DuplicateEntityException : Exception
{
    public DuplicateEntityException(string? message) : base(message)
    {
    }
}