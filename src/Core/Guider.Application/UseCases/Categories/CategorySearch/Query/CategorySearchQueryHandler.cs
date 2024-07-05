using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Categories.CategorySearch.Query
{
    public class CategorySearchQueryHandler : IRequestHandler<CategorySearchQuery, List<CategorySearchDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategorySearchQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategorySearchDto>> Handle(CategorySearchQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _categoryRepository.SearchConsultantsByCategoryAsync(request.CategoryId, request.ConsultantName);
            return _mapper.Map<List<CategorySearchDto>>(consultants);
        }
    }
}
