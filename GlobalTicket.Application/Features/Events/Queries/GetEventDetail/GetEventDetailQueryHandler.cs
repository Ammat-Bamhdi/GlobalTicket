using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using MediatR;
// Library for automatic mapping between objects
// Interface for data access layer
// Namespace containing GetEventDetailQuery class
// Namespace containing EventDetailViewModel class
// Class definitions for domain objects (like Event and Category)

// Library for handling requests and responses in applications

namespace GlobalTicket.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler(
        IAsyncRepository<Event> eventRepository,
        IAsyncRepository<Category> categoryRepository,
        IMapper mapper)
    
        : IRequestHandler<GetEventDetailQuery,
            EventDetailViewModel> // Interface indicating this class handles GetEventDetailQuery requests
    {
        // Dependency injection for accessing Event data
        // Dependency injection for accessing Category data
        // Dependency injection for object mapping

        public async Task<EventDetailViewModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            // 1. Retrieve the Event details by its ID asynchronously
            var @event = await eventRepository.GetByIdAsync(request.Id);

            // **Explanation:**
            //  - We use `_eventRepository.GetByIdAsync(request.Id)` to retrieve the specific Event object 
            //    matching the `Id` provided in the `GetEventDetailQuery` request.
            //  - The result is awaited to ensure the data is available before proceeding.

            // 2. Map the retrieved Event to an EventDetailViewModel using AutoMapper
            var eventDto = mapper.Map<EventDetailViewModel>(@event);

            // **Explanation:**
            //  - We use the injected `_mapper` instance to transform the retrieved `@event` object 
            //    into an `EventDetailViewModel`.
            //  - This assumes a mapping configuration exists between these two types (profile)

            // 3. Retrieve the Category associated with the Event (using its CategoryId)
            var category = await categoryRepository.GetByIdAsync(@event.CategoryId);

            // **Explanation:**
            //  - We use `_categoryRepository.GetByIdAsync(@event.CategoryId)` to retrieve the Category 
            //    object associated with the retrieved Event (using its CategoryId property).
            //  - The result is awaited to ensure the data is available before proceeding.

            // 4. Map the retrieved Category to a CategoryDto using AutoMapper and populate the EventDetailViewModel
            eventDto.Category = mapper.Map<CategoryDto>(category);

            // **Explanation:**
            //  - We use the injected `_mapper` again to transform the retrieved `category` object 
            //    into a `CategoryDto`.
            //  - This assumes a mapping configuration exists between these types.
            //  - Finally, we populate the `Category` property of the `eventDto` (EventDetailViewModel) 
            //    with the mapped `CategoryDto` object.

            return eventDto;
        }
    }
}