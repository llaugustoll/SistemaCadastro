using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.API.Controllers.V1.Models;
using System.Threading.Tasks;

namespace SistemaCadastro.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class CadastroController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCadastroRequest cadastro)
    {
        var result = await mediator.Send(new CreateCadastroCommand
            (
                cadastro.Documento,
                cadastro.Nome,
                cadastro.Cep,
                cadastro.NumeroResidencia
             ));

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object cpfDto)
    {
        return NoContent();
    }

    [HttpDelete("{documento}")]
    public async Task<IActionResult> Delete(string documento)
    {
        var result = await mediator.Send(new DeleteCadastroCommand(documento));

        if (result)
            return NoContent();

        return BadRequest();
    }
}
