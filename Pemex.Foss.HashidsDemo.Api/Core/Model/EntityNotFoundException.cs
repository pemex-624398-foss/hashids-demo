namespace Pemex.Foss.HashidsDemo.Api.Core.Model;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string? message) : base(message)
    {
    }
}