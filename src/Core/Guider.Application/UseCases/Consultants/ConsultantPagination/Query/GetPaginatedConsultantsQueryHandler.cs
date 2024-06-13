using AutoMapper;
using Guider.Application.UseCases.Consultants.ConsultantSearch.Query;
using Guider.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantPagination.Query
{
    public class GetPaginatedConsultantsQueryHandler : IRequestHandler<GetPaginatedConsultantsQuery, List<ConsultantDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public GetPaginatedConsultantsQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<List<ConsultantDto>> Handle(GetPaginatedConsultantsQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.GetPaginatedConsultantsAsync(request.Page, request.PageSize);
            return consultants.Select(c => _mapper.Map<ConsultantDto>(c)).ToList();
        }
    }
}