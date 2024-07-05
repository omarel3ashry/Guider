using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query
{
    public class SearchConsultantsBySubCategoryQueryHandler : IRequestHandler<SearchConsultantsBySubCategoryQuery, List<SubCategorySearchDto>>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SearchConsultantsBySubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<SubCategorySearchDto>> Handle(SearchConsultantsBySubCategoryQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _subCategoryRepository.SearchConsultantsBySubCategoryAsync(request.SubCategoryId, request.ConsultantName);
            return consultants.Select(c => _mapper.Map<SubCategorySearchDto>(c)).ToList();
        }

    }
}