namespace Pemex.Foss.HashidsDemo.Api.Core.Features.CrearEmpleadoCommand;

public class CrearEmpleadoCommandResult
{
    public CrearEmpleadoCommandResult(string idEmpleado)
    {
        IdEmpleado = idEmpleado;
    }

    public string IdEmpleado { get; }
}