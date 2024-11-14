using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListViewModel>>
    {
        public async Task<List<CategoryEventListViewModel>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return mapper.Map<List<CategoryEventListViewModel>>(list);
        }
    }
}
