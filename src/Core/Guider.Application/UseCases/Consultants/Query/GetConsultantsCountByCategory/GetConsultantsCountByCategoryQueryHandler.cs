using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.Consultants.Query.GetConsultantsCountByCategory;
using Guider.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Categories.Queries
{
    public class GetConsultantsCountByCategoryQueryHandler : IRequestHandler<GetConsultantsCountByCategoryQuery, List<ConsultantsCountByCategoryDto>>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IMapper _mapper;

        public GetConsultantsCountByCategoryQueryHandler(IConsultantRepository consultantRepository, IMapper mapper)
        {
            _consultantRepository = consultantRepository;
            _mapper = mapper;
        }

        public async Task<List<ConsultantsCountByCategoryDto>> Handle(GetConsultantsCountByCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _consultantRepository.GetCategoriesWithConsultantsAsync();

            var result = _mapper.Map<List<ConsultantsCountByCategoryDto>>(categories);

            return result;
        }
    }
}
