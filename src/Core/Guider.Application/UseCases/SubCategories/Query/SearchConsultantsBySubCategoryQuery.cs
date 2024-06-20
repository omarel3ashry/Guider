using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.SubCategories.Query
{
    public class SearchConsultantsBySubCategoryQuery : IRequest<List<SubCategorySearchDto>>
    {
        public int SubCategoryId { get; set; }
        public string ConsultantName { get; set; }
    }
}
