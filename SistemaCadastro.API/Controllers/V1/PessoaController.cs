using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.API.Controllers.V1.Models;
using SistemaCadastro.Application.CQRS.V1.Commands;
using SistemaCadastro.Application.Models.Responses;

namespace SistemaCadastro.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class PessoaController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetCadastroByIdCommand(id));

        if (result == null)
            return NotFound(new {message = "Cliente não encontrado"});

        return Ok(result);
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
