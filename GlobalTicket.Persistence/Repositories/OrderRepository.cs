using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Persistence.Repositories;

public class OrderRepository(GlobalTicketDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
    public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int page_size)
    {
        // Filter orders for the specified month and year
        var filteredOrders = _dbContext.Orders.Where(order =>
            order.OrderPlaced.Month == date.Month &&
            order.OrderPlaced.Year == date.Year
        );

        // Apply pagination: skip the specified number of records and take the desired page size
        var pagedOrders = filteredOrders.Skip((page - 1) * page_size)
            .Take(page_size);

        // Disable tracking to improve performance (as we're only reading data)
        var query = pagedOrders.AsNoTracking();

        // Execute the query asynchronously and return the result as a list of orders
        return await query.ToListAsync();
    }
    public Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
    {
        throw new NotImplementedException();
    }
}