using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantSort.Query
{
    public class SortByHourlyRateQuery : IRequest<List<SortByHourlyRateDto>>
    {
        public bool Ascending { get; }

        public SortByHourlyRateQuery(bool ascending)
        {
            Ascending = ascending;
        }
    }
}
