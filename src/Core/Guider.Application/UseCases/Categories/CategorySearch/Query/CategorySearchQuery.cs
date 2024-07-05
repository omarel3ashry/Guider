using MediatR;

namespace Guider.Application.UseCases.Categories.CategorySearch.Query
{
    public class CategorySearchQuery : IRequest<List<CategorySearchDto>>
    {
        public int CategoryId { get; set; }
        public string ConsultantName { get; set; }

        public CategorySearchQuery(int categoryId, string consultantName = null)
        {
            CategoryId = categoryId;
            ConsultantName = consultantName;
        }
    }
}
