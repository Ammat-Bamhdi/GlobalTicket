using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using MediatR;
// Library for automatic mapping between objects
// Interface for data access layer
// Class definitions for domain objects (like Event)

// Library for handling requests and responses in applications

namespace GlobalTicket.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        : IRequestHandler<GetEventListQuery, List<EventListViewModel>>
    {
        // Dependency injection for accessing Event data
        // Dependency injection for object mapping

        public async Task<List<EventListViewModel>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            // 1. Retrieve all Events from the data store asynchronously
            // **Explanation:**
            //  - We use `_eventRepository.ListAllAsync()` to retrieve all Event objects from the database asynchronously.
            //  - The result is awaited to ensure the data is available before proceeding.
            //  - `.OrderBy(x => x.Date)` sorts the retrieved events by their Date property in ascending order.
            var allEvents = (await eventRepository.ListAllAsync()).OrderBy(x => x.Date);
            
            // 2. Map the list of Events to a list of EventListViewModel using AutoMapper
            // **Explanation:**
            //  - We use the injected `_mapper` instance provided by AutoMapper.
            //  - The `Map` method takes the list of `allEvents` and transforms them into a list of `EventListViewModel` objects.
            //  - This assumes a mapping configuration exists between these two types.
            return mapper.Map<List<EventListViewModel>>(allEvents);
        }
    }
}