using MediatR;
using Mercadinho.Prateleira.API.Application.Categoria.Query;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;

namespace Mercadinho.Prateleira.API.Application.Categoria.Handler
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Categoria>>
    {

        private readonly IGenericRepository<Domain.Categoria> _repository;

        public GetAllCategoryQueryHandler(IGenericRepository<Domain.Categoria> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Domain.Categoria>> Handle(GetAllCategoriesQuery request,
                                                                CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
