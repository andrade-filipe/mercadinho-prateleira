using MediatR;
using Mercadinho.Prateleira.API.Application.Categoria.Command;
using Mercadinho.Prateleira.API.Application.Categoria.Query;
using Microsoft.AspNetCore.Mvc;

namespace Mercadinho.Prateleira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categories = await _mediator
                .Send(new GetAllCategoriesQuery(), cancellationToken)
                .ConfigureAwait(false);

            return categories.Any() ? Ok(categories) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            if (!command.Validation.IsValid)
            {
                return BadRequest(command.Validation.Errors);
            }

            var sucesso = await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryCommand command,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

    }
}