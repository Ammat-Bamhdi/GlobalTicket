﻿namespace GlobalTicket.Application.Features.Orders.GetOrdersForMonth
{
    public class PagedOrdersForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthDto>? OrdersForMonth{ get; set; }
    }
}