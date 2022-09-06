using AutoMapper;
using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Model;
using Pemex.Foss.HashidsDemo.Api.Core.Util;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadoByIdQuery;

public class GetEmpleadoByIdQuery : IRequestHandler<GetEmpleadoByIdQueryArgument, EmpleadoDto?>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IHasher _hasher;
    private readonly IMapper _mapper;

    public GetEmpleadoByIdQuery(IEmpleadoRepository empleadoRepository, IHasher hasher, IMapper mapper)
    {
        _empleadoRepository = empleadoRepository;
        _hasher = hasher;
        _mapper = mapper;
    }

    public async Task<EmpleadoDto?> Handle(GetEmpleadoByIdQueryArgument request, CancellationToken cancellationToken)
    {
        var idEmpleado = _hasher.DecodeInt(request.IdEmpleado);
        var empleado = await _empleadoRepository.GetByIdAsync(idEmpleado);
        
        return empleado is not null
            ? _mapper.Map<EmpleadoDto>(empleado)
            : null;
    }
}