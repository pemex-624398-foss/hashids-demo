using AutoMapper;
using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Model;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.ActualizarEmpleadoCommand;

public class ActualizarEmpleadoCommandHandler : IRequestHandler<ActualizarEmpleadoCommandArgument>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IMapper _mapper;

    public ActualizarEmpleadoCommandHandler(IEmpleadoRepository empleadoRepository, IMapper mapper)
    {
        _empleadoRepository = empleadoRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ActualizarEmpleadoCommandArgument request, CancellationToken cancellationToken)
    {
        var empleado = _mapper.Map<Empleado>(request);
        await _empleadoRepository.UpdateAsync(empleado);
        return Unit.Value;
    }
}