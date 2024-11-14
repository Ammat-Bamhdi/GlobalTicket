using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GlobalTicket.Application.Exceptions;
using GloboTicket.Domain.Entities;
using MediatR;

namespace GlobalTicket.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        
        var @event = mapper.Map<Event>(request);

        var validator = new CreateEventCommandValidator(eventRepository);
        var validateResult 
            = await validator.ValidateAsync(request);
        if (validateResult.Errors.Count > 0)
            throw new ValidationException(validateResult);
    
        @event = await eventRepository.AddAsync(@event);
        return @event.EventId;
    }
}