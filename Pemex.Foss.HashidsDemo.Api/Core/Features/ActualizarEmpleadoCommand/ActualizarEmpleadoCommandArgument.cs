using MediatR;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.ActualizarEmpleadoCommand;

public class ActualizarEmpleadoCommandArgument : IRequest
{
    public string IdEmpleado { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; }
    public string Correo { get; set; } = string.Empty;
    public string Rfc { get; set; } = string.Empty;
    public int Ficha { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}