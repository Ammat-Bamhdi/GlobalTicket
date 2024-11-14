using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GlobalTicketDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetCategoriesWithEvents(bool includePastEvents) // Use "past" instead of "passed" for clarity
    {
        // Get all categories along with their associated events
        var categoriesWithEvents = await _dbContext.Categories
            .Include(category => category.Events)
            .ToListAsync();

        // If filtering for upcoming events only, remove past events from each category
        if (!includePastEvents)
            categoriesWithEvents.ForEach(category => category.Events.ToList().RemoveAll(@event => @event.Date < DateTime.Today));

        // Return the list of categories, potentially with filtered events
        return categoriesWithEvents;
    }
}