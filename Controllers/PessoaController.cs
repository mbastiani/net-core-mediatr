using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreMediator.Domain.Pessoa.Command;
using System.Threading.Tasks;

namespace NetCoreMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaCreateCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.NonSuccessMessage);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] long id, [FromBody] PessoaUpdateCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.NonSuccessMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new PessoaDeleteCommand { Id = id });
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.NonSuccessMessage);
        }
    }
}
