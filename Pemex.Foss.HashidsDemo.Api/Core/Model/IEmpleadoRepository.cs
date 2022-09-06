namespace Pemex.Foss.HashidsDemo.Api.Core.Model;

public interface IEmpleadoRepository
{
    Task<Empleado?> GetByIdAsync(int idEmpleado);
    Task<IEnumerable<Empleado>> GetAllAsync();
    Task<int> CreateAsync(Empleado empleado);
    Task UpdateAsync(Empleado empleado);
    Task DeleteAsync(int idEmpleado);
}