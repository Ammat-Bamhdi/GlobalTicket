﻿using MediatR;

namespace GlobalTicket.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery: IRequest<List<CategoryEventListViewModel>>
    {
        public bool IncludeHistory { get; set; }
    }
}