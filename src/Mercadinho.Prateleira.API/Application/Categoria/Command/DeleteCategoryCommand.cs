using MediatR;

namespace Mercadinho.Prateleira.API.Application.Categoria.Command
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
