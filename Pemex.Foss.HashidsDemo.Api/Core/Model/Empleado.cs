namespace Pemex.Foss.HashidsDemo.Api.Core.Model;

public class Empleado
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Apellido { get; set; }
    public string Correo { get; set; } = string.Empty;
    public string Rfc { get; set; } = string.Empty;
    public int Ficha { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
}