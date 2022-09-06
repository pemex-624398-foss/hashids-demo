using MediatR;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadosQuery;

public class GetEmpleadosQueryArgument : IRequest<IEnumerable<EmpleadoDto>>
{
}