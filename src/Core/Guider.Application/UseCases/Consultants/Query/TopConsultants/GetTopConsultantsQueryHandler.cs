using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.TopConsultants
{
    public class GetTopConsultantsQueryHandler : IRequestHandler<GetTopConsultantsQuery, List<TopConsultantsDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public GetTopConsultantsQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
            
        }
        public async Task<List<TopConsultantsDto>> Handle(GetTopConsultantsQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetTopConsultantsByAverageRateAsync();

            return _mapper.Map<List<TopConsultantsDto>>(consultants);
        }
    }
}
