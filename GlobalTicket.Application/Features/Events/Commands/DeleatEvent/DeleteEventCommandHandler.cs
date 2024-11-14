using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using MediatR;

namespace GlobalTicket.Application.Features.Events.Commands.DeleatEvent;

public class DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    : IRequestHandler<DeleteEventCommand>
{

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);

        if (eventToDelete == null)
        {
            throw new Exception(nameof(Event));
        }

        await eventRepository.DeleteAsync(eventToDelete);
    }
}