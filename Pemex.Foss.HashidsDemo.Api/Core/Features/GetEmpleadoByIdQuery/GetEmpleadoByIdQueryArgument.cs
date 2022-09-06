using MediatR;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadoByIdQuery;

public class GetEmpleadoByIdQueryArgument : IRequest<EmpleadoDto?>
{
    public GetEmpleadoByIdQueryArgument(string idEmpleado)
    {
        IdEmpleado = idEmpleado;
    }

    public string IdEmpleado { get; }
}