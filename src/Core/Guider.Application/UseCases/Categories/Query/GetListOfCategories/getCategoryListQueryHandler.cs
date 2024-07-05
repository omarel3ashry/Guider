using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Categories.Query.GetListOfCategories
{
    public class getCategoryListQueryHandler : IRequestHandler<getCategoryListQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryrepository;

        public getCategoryListQueryHandler(IMapper mapper, ICategoryRepository categoryrepository)
        {
            _mapper = mapper;
            _categoryrepository = categoryrepository;
        }
        public async Task<List<CategoryDto>> Handle(getCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryrepository.GetAllWithSubCategories();
            var categoryListDto = _mapper.Map<List<CategoryDto>>(categoryList);
            return categoryListDto;
        }
    }
}
