using Guider.Application.UseCases.Categories.CategorySearch.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Categories.Query.GetListOfCategories
{

    public class getCategoryListQuery:IRequest<List<CategoryDto>>
    {
    }
}
