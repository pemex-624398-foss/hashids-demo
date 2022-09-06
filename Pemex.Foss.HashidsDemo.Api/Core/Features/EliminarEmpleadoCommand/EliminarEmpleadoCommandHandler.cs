using MediatR;
using Pemex.Foss.HashidsDemo.Api.Core.Model;
using Pemex.Foss.HashidsDemo.Api.Core.Util;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features.EliminarEmpleadoCommand;

public class EliminarEmpleadoCommandHandler : IRequestHandler<EliminarEmpleadoCommandArgument>
{
    private readonly IEmpleadoRepository _empleadoRepository;
    private readonly IHasher _hasher;

    public EliminarEmpleadoCommandHandler(IEmpleadoRepository empleadoRepository, IHasher hasher)
    {
        _empleadoRepository = empleadoRepository;
        _hasher = hasher;
    }

    public async Task<Unit> Handle(EliminarEmpleadoCommandArgument request, CancellationToken cancellationToken)
    {
        var idEmpleado = _hasher.DecodeInt(request.IdEmpleado);
        await _empleadoRepository.DeleteAsync(idEmpleado);
        return Unit.Value;
    }
}