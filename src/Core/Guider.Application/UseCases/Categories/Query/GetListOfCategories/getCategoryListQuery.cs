using MediatR;

namespace Guider.Application.UseCases.Categories.Query.GetListOfCategories
{

    public class getCategoryListQuery : IRequest<List<CategoryDto>>
    {
    }
}
