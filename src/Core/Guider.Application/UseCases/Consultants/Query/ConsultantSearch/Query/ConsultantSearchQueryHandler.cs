using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantSearch.Query
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
