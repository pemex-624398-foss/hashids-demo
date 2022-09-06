using AutoMapper;
using Pemex.Foss.HashidsDemo.Api.Core.Features.ActualizarEmpleadoCommand;
using Pemex.Foss.HashidsDemo.Api.Core.Features.CrearEmpleadoCommand;
using Pemex.Foss.HashidsDemo.Api.Core.Model;
using Pemex.Foss.HashidsDemo.Api.Core.Util;

namespace Pemex.Foss.HashidsDemo.Api.Core.Features;

public class EmpleadoMapping : Profile
{
    public EmpleadoMapping(IHasher hasher)
    {
        CreateMap<CrearEmpleadoCommandArgument, Empleado>();
        
        CreateMap<ActualizarEmpleadoCommandArgument, Empleado>()
            .ForMember(destination => destination.IdEmpleado, options =>
            {
                options.MapFrom(source => hasher.DecodeInt(source.IdEmpleado));
            });

        CreateMap<Empleado, EmpleadoDto>()
            .ForMember(destination => destination.IdEmpleado, options =>
            {
                options.MapFrom(source => hasher.Encode(source.IdEmpleado));
            });
    }
}