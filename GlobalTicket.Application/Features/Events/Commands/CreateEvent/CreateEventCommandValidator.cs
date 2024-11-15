﻿using FluentValidation;
using GlobalTicket.Application.Contracts.Persistence;

namespace GlobalTicket.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
     private readonly IEventRepository _eventRepository;
    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
    }

    private async Task<bool> EventNameAndDateUnique(CreateEventCommand createEventCommand,
        CancellationToken cancellationToken)
    {
        return !(await _eventRepository.IsEventNameAndDateUnique(createEventCommand.Name, createEventCommand.Date));
    }
}