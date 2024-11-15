﻿using FluentValidation.Results;

namespace GlobalTicket.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValdationErrors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
        ValdationErrors = [];

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}