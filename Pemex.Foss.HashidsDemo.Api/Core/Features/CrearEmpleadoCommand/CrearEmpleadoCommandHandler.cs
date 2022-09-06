using AutoMapper;
using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Model;
using Pemex.Foss.HashidsDemo.Api.Core.Util;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.CrearEmpleadoCommand;

public class CrearEmpleadoCommandHandler : IRequestHandler<CrearEmpleadoCommandArgument, CrearEmpleadoCommandResult>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IMapper _mapper;
    private readonly IHasher _hasher;

    public CrearEmpleadoCommandHandler(IEmpleadoRepository empleadoRepository, IMapper mapper, IHasher hasher)
    {
        _empleadoRepository = empleadoRepository;
        _mapper = mapper;
        _hasher = hasher;
    }

    public async Task<CrearEmpleadoCommandResult> Handle(CrearEmpleadoCommandArgument request, CancellationToken cancellationToken)
    {
        var empleado = _mapper.Map<Empleado>(request);
        var idEmpleado = await _empleadoRepository.CreateAsync(empleado);
        var hashId = _hasher.Encode(idEmpleado);

        return new CrearEmpleadoCommandResult(hashId);
    }
}