using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantSearch
{
    public class ConsultantSearchQueryHandler : IRequestHandler<ConsultantSearchQuery, PaginatedConsultantDto>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public ConsultantSearchQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedConsultantDto> Handle(ConsultantSearchQuery request, CancellationToken cancellationToken)
        {
            var (consultants, totalCount) = await _consultantRepository.SearchConsultantsAsync(request.SearchQuery, request.page, request.pageSize);
            var consultantDtos = _mapper.Map<List<ConsultantDto>>(consultants);

            return new PaginatedConsultantDto
            {
                Consultants = consultantDtos,
                TotalCount = totalCount
            };

        }
    }
}