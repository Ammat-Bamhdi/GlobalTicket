using GloboTicket.Domain.Entities;

namespace GlobalTicket.Application.Contracts.Persistence;

public interface IEventRepository : IAsyncRepository<Event>
{
    Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
}