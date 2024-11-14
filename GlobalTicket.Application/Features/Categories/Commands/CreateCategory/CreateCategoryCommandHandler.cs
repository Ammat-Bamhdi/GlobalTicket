using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using MediatR;
// Used for object mapping between request and response objects
// Interface for accessing category persistence layer
// Namespace containing the Category entity definition

// Interface for handling MediatR requests

namespace GlobalTicket.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
    : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();

        // Validate the request using a validator
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = [];
            foreach (var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
            // Return the response with validation errors if validation fails
            return createCategoryCommandResponse;
        }

        // Create a new Category entity from the request data
        var category = new Category() { Name = request.Name };

        // Add the category to the persistence layer using the repository
        category = await categoryRepository.AddAsync(category);

        // Map the created Category entity to a CreateCategoryDto object for response
        createCategoryCommandResponse.Category = mapper.Map<CreateCategoryDto>(category);

        return createCategoryCommandResponse;
    }
}