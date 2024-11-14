using MediatR;

namespace GlobalTicket.Application.Features.Events.Commands.DeleatEvent;

public class DeleteEventCommand : IRequest
{
    public Guid EventId { get; set; }
}