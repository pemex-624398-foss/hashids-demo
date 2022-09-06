using AutoMapper;
using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadoByIdQuery;
using Pemex.Foss.HashidsDemo.Api.Core.Model;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadosQuery;

public class GetEmpleadosQuery : IRequestHandler<GetEmpleadosQueryArgument, IEnumerable<EmpleadoDto>>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IMapper _mapper;

    public GetEmpleadosQuery(IEmpleadoRepository empleadoRepository, IMapper mapper)
    {
        _empleadoRepository = empleadoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmpleadoDto>> Handle(GetEmpleadosQueryArgument request, CancellationToken cancellationToken)
    {
        var empleados = await _empleadoRepository.GetAllAsync();
     
        return empleados.Select(e => _mapper.Map<EmpleadoDto>(e));
    }
}