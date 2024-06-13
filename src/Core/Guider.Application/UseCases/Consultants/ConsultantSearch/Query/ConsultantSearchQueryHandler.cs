using AutoMapper;
using Guider.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSearch.Query
{
    public class ConsultantSearchQueryHandler : IRequestHandler<ConsultantSearchQuery, List<ConsultantSearchDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public ConsultantSearchQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<List<ConsultantSearchDto>> Handle(ConsultantSearchQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetConsultantsByUserNameAsync(request.SearchQuery);
            return consultants.Select(c => _mapper.Map<ConsultantSearchDto>(c)).ToList();
        }
    }
}
