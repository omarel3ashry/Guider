using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query
{
    public class SearchConsultantsBySubCategoryQuery : IRequest<List<SubCategorySearchDto>>
    {
        public int SubCategoryId { get; set; }
        public string ConsultantName { get; set; }
    }
}
