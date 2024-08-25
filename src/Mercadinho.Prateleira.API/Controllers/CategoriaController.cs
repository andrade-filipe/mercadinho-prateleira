using MediatR;
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

    }
}
