using AutoMapper;
using GlobalTicket.Application.Features.Categories.Commands.CreateCategory;
using GlobalTicket.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GlobalTicket.Application.Features.Events;
using GlobalTicket.Application.Features.Events.Commands.CreateEvent;
using GlobalTicket.Application.Features.Events.Commands.DeleatEvent;
using GlobalTicket.Application.Features.Events.Commands.UpdateEvent;
using GlobalTicket.Application.Features.Events.Queries.GetEventDetail;
using GlobalTicket.Application.Features.Events.Queries.GetEventList;
using GlobalTicket.Application.Features.Orders.GetOrdersForMonth;
using GloboTicket.Domain.Entities;

namespace GlobalTicket.Application.Profiles;

public class MappingProfile : Profile
{
    protected MappingProfile()
    {
        CreateMap<Event, EventListViewModel>().ReverseMap();
        CreateMap<Event, EventDetailViewModel>().ReverseMap();
        CreateMap<Event,CreateEventCommand>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, DeleteEventCommand>().ReverseMap();
        
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListViewModel>();
        CreateMap<Category, CategoryEventListViewModel>();
        CreateMap<Category, CreateCategoryCommand>();
        CreateMap<Category, CreateCategoryDto>();
        
        CreateMap<Order, OrdersForMonthDto>();
    }
}