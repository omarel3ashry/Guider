using AutoMapper;
using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using Guider.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantsAll.Query
{
    public class GetAllConsultantsQueryHandler : IRequestHandler<GetAllConsultantsQuery, List<ConsultantDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public GetAllConsultantsQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<List<ConsultantDto>> Handle(GetAllConsultantsQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetAllConsultantsAsync();
            return _mapper.Map<List<ConsultantDto>>(consultants);
        }
    }
}