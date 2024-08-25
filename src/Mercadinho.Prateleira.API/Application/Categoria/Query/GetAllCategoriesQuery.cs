using MediatR;

namespace Mercadinho.Prateleira.API.Application.Categoria.Query
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Domain.Categoria>>
    {
    }
}
