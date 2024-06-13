using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSearch.Query
{
    public class ConsultantSearchQuery : IRequest<List<ConsultantSearchDto>>
    {
        public string SearchQuery { get; set; }

        public ConsultantSearchQuery(string searchQuery)
        {
            SearchQuery = searchQuery;
        }
    }
}
