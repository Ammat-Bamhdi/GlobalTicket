using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthViewModel>
    {
        public async Task<PagedOrdersForMonthViewModel> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            var orders =  mapper.Map<List<OrdersForMonthDto>>(list);

            var count = await orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            return new PagedOrdersForMonthViewModel() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };
        }
    }
}
