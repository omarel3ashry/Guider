using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.SubCategories.Query.getSubCategoryByCategoryId
{
    public class getSubCategoryByCategoryIdQuery:IRequest<List<subCategoryDto>>
    {
  
        public int categoryId { get; set; }
    
    }
}
