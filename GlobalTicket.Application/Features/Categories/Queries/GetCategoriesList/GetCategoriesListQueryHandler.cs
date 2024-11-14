using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using MediatR;

namespace GlobalTicket.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        : IRequestHandler<GetCategoriesListQuery, List<CategoryListViewModel>>
    {
        public async Task<List<CategoryListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return mapper.Map<List<CategoryListViewModel>>(allCategories);
        }
    }
}
