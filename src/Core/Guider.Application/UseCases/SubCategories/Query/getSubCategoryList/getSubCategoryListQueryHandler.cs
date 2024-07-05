using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.SubCategories.Query.getSubCategoryList
{
    public class getSubCategoryListQueryHandler : IRequestHandler<getSubCategoryListQuery, List<subCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SubCategory> _subcategoryrepository;
        public getSubCategoryListQueryHandler(IMapper mapper, IRepository<SubCategory> subcategoryrepository)
        {
            _mapper = mapper;
            _subcategoryrepository = subcategoryrepository;
        }

        public async Task<List<subCategoryDto>> Handle(getSubCategoryListQuery request, CancellationToken cancellationToken)
        {
            var subCategoryList = await _subcategoryrepository.ListAllAsync();
            return _mapper.Map<List<subCategoryDto>>(subCategoryList);
        }
    }
}
