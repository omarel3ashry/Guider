using AutoMapper;
using Guider.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSortt.Query
{

    public class SortByHourlyRateQueryHandler : IRequestHandler<SortByHourlyRateQuery, List<SortByHourlyRateDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public SortByHourlyRateQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }
        public async Task<List<SortByHourlyRateDto>> Handle(SortByHourlyRateQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetSortedByHourlyRateAsync(request.Ascending);
            return _mapper.Map<List<SortByHourlyRateDto>>(consultants);
        }
    }
}
