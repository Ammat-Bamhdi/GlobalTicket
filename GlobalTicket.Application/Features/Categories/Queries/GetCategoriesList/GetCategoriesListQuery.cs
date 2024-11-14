using MediatR;

namespace GlobalTicket.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListViewModel>>
    {
    }
}
