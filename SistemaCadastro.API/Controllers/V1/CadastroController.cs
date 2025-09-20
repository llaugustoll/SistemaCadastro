using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.API.Controllers.V1.Models;

namespace SistemaCadastro.API.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class CadastroController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCadastroRequest cadastro)
    {
        return CreatedAtAction(nameof(GetById), new { id = 0 }, null);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] object cpfDto)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
