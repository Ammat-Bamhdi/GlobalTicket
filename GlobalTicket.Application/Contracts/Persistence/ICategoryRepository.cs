using GloboTicket.Domain.Entities;

namespace GlobalTicket.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);

}