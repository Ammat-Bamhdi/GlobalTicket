using System.ComponentModel.DataAnnotations;
using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GlobalTicket.Application.Features.Events.Commands.DeleatEvent;
using GloboTicket.Domain.Entities;
using MediatR;

namespace GlobalTicket.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    : IRequestHandler<UpdateEventCommand>
{
    private readonly IMapper _mapper = mapper;

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await eventRepository.GetByIdAsync(request.EventId);

        if (eventToDelete == null)
        {
            throw new Exception(nameof(Event));
        }

        await eventRepository.DeleteAsync(eventToDelete);
    }
}