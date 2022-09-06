using MediatR;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.CrearEmpleadoCommand;

public class CrearEmpleadoCommandArgument : IRequest<CrearEmpleadoCommandResult>
{
    public string Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; }
    public string Correo { get; set; } = string.Empty;
    public string Rfc { get; set; } = string.Empty;
    public int Ficha { get; set; }
}