using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pemex.Foss.HashidsDemo.Api.Core.Features.ActualizarEmpleadoCommand;
using Pemex.Foss.HashidsDemo.Api.Core.Features.CrearEmpleadoCommand;
using Pemex.Foss.HashidsDemo.Api.Core.Features.EliminarEmpleadoCommand;
using Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadoByIdQuery;
using Pemex.Foss.HashidsDemo.Api.Core.Features.GetEmpleadosQuery;

namespace Pemex.Foss.HashidsDemo.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmpleadoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var argument = new GetEmpleadosQueryArgument();
        var result = await _mediator.Send(argument);
        return Ok(result);
    }

    [HttpGet("{idEmpleado}")]
    public async Task<IActionResult> GetById(string idEmpleado)
    {
        var argument = new GetEmpleadoByIdQueryArgument(idEmpleado);
        var result = await _mediator.Send(argument);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearEmpleadoCommandArgument argument)
    {
        var result = await _mediator.Send(argument);
        return Ok(result);
    }

    [HttpPut("{idEmpleado}")]
    public async Task<IActionResult> Update(string idEmpleado, [FromBody] ActualizarEmpleadoCommandArgument argument)
    {
        argument.IdEmpleado = idEmpleado;
        await _mediator.Send(argument);
        return Ok();
    }

    [HttpDelete("{idEmpleado}")]
    public async Task<IActionResult> Delete(string idEmpleado)
    {
        await _mediator.Send(new EliminarEmpleadoCommandArgument(idEmpleado));
        return Ok();
    }
}