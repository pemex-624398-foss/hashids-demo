using Pemex.Foss.HashidsDemo.Api.Core.Model;

namespace Pemex.Foss.HashidsDemo.Api.Infrastructure.Database;

public class EmpleadoRepository : IEmpleadoRepository
{
    private static readonly List<Empleado> Empleados;

    static EmpleadoRepository()
    {
        Empleados = new List<Empleado>(new[]
        {
            new Empleado
            {
                IdEmpleado = 1,
                Nombre = "Juan",
                Apellido = "Perez",
                Correo = "juan.perez@pemex.com",
                Rfc = "ABC",
                Ficha = 123456,
                FechaCreacion = DateTime.Now
            },
            new Empleado
            {
                IdEmpleado = 2,
                Nombre = "Maria",
                Apellido = "Lopez",
                Correo = "maria.lopez@pemex.com",
                Rfc = "DEF",
                Ficha = 987654,
                FechaCreacion = DateTime.Now
            }
        });
    }

    public Task<Empleado?> GetByIdAsync(int idEmpleado)
    {
        return Task.FromResult(Empleados.FirstOrDefault(e => e.IdEmpleado == idEmpleado));
    }

    public Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return Task.FromResult(Empleados.AsEnumerable());
    }

    public async Task<int> CreateAsync(Empleado empleado)
    {
        var empleadoExistente = Empleados.FirstOrDefault(e => e.Correo == empleado.Correo);
        if (empleadoExistente is not null)
            throw new DuplicateEntityException($"El correo electrónico '{empleado.Correo}' ya se encuentra asociado a otro registro de empleado.");
        
        empleadoExistente = Empleados.FirstOrDefault(e => e.Rfc == empleado.Rfc);
        if (empleadoExistente is not null)
            throw new DuplicateEntityException($"El RFC '{empleado.Rfc}' ya se encuentra asociado a otro registro de empleado.");
        
        empleadoExistente = Empleados.FirstOrDefault(e => e.Ficha == empleado.Ficha);
        if (empleadoExistente is not null)
            throw new DuplicateEntityException($"La ficha '{empleado.Ficha}' ya se encuentra asociado a otro registro de empleado.");
        
        var id = await Task.Run(() =>
        {
            var nuevoEmpleado = new Empleado
            {
                IdEmpleado = Empleados.Any()
                    ? Empleados.Max(e => e.IdEmpleado) + 1 
                    : 1,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Correo = empleado.Correo,
                Rfc = empleado.Rfc,
                Ficha = empleado.Ficha,
                FechaCreacion = new DateTime()
            };
            Empleados.Add(nuevoEmpleado);
            return nuevoEmpleado.IdEmpleado;
        });
        return id;
    }

    public async Task UpdateAsync(Empleado empleado)
    {
        var empleadoExistente = await GetByIdAsync(empleado.IdEmpleado);
        if (empleadoExistente is null)
            throw NewEntityNotFoundException(empleado.IdEmpleado);
        
        if (Empleados.Any(e => e.IdEmpleado != empleado.IdEmpleado && e.Correo == empleado.Correo))
            throw new DuplicateEntityException($"El correo electrónico '{empleado.Correo}' ya se encuentra asociado a otro registro de empleado.");
        
        if (Empleados.Any(e => e.IdEmpleado != empleado.IdEmpleado && e.Rfc == empleado.Rfc))
            throw new DuplicateEntityException($"El RFC '{empleado.Rfc}' ya se encuentra asociado a otro registro de empleado.");
        
        if (Empleados.Any(e => e.IdEmpleado != empleado.IdEmpleado && e.Ficha == empleado.Ficha))
            throw new DuplicateEntityException($"La ficha '{empleado.Ficha}' ya se encuentra asociado a otro registro de empleado.");
        
        empleadoExistente.Nombre = empleado.Nombre;
        empleadoExistente.Apellido = empleado.Apellido;
        empleadoExistente.Correo = empleado.Correo;
        empleadoExistente.Rfc = empleado.Rfc;
        empleadoExistente.Ficha = empleado.Ficha;
        empleadoExistente.FechaModificacion = DateTime.Now;
    }

    public async Task DeleteAsync(int idEmpleado)
    {
        var empleadoExistente = await GetByIdAsync(idEmpleado);
        if (empleadoExistente is null)
            throw NewEntityNotFoundException(idEmpleado);

        Empleados.Remove(empleadoExistente);
    }

    private static EntityNotFoundException NewEntityNotFoundException(int id)
        => new EntityNotFoundException($"No se encontró el empleado con identificador {id}.");
}