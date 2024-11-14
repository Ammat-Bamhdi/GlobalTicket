using GlobalTicket.Application.Response;

namespace GlobalTicket.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse(): base()
    {

    }

    public CreateCategoryDto Category { get; set; } = default!;
}