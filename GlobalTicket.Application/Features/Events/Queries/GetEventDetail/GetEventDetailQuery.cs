using MediatR;

namespace GlobalTicket.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery : IRequest<EventDetailViewModel>
{
    public Guid Id { get; set; }
}