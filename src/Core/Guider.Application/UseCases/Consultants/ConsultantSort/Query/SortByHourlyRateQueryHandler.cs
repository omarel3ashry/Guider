using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using MediatR;

namespace Guider.Application.UseCases.Consultants.ConsultantSortt.Query
{

    public class SortByHourlyRateQueryHandler : IRequestHandler<SortByHourlyRateQuery, PaginatedConsultantDto>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;
        public SortByHourlyRateQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedConsultantDto> Handle(SortByHourlyRateQuery request, CancellationToken cancellationToken)
        {
            var (consultants, totalCount) = await _consultantRepository.GetSortedByHourlyRateAsync(request.Ascending, request.Page, request.PageSize);
            var consultantDtos = _mapper.Map<List<ConsultantDto>>(consultants);

            return new PaginatedConsultantDto
            {
                Consultants = consultantDtos,
                TotalCount = totalCount
            };
        }
    }
}
