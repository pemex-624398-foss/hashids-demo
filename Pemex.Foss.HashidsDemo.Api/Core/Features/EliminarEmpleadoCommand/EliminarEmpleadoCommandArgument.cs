using MediatR;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.EliminarEmpleadoCommand;

public class EliminarEmpleadoCommandArgument : IRequest
{
    public EliminarEmpleadoCommandArgument(string idEmpleado)
    {
        IdEmpleado = idEmpleado;
    }

    public string IdEmpleado { get; }
}