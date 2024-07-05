using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query.getSubCategoryByCategoryId
{
    public class getSubCategoryByCategoryIdQuery : IRequest<List<subCategoryDto>>
    {

        public int categoryId { get; set; }

    }
}
