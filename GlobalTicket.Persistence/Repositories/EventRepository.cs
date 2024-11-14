using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;

namespace GlobalTicket.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(GlobalTicketDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        var matches 
            = _dbContext.Events.Any(
                @event => @event.Name.Equals(name) && @event.Date.Equals(eventDate)
                );
        return Task.FromResult(matches);
    }
}