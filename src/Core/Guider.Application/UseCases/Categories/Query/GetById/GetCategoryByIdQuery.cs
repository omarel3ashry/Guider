using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Categories.Query.GetById
{
    public class GetCategoryByIdQuery : IRequest<BaseResponse<CategoryDto>>
    {
        public int Id { get; set; }
    }
}
