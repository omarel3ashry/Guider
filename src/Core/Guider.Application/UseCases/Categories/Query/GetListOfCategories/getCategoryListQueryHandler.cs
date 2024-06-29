using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Categories.Query.GetListOfCategories
{
    public class getCategoryListQueryHandler : IRequestHandler<getCategoryListQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryrepository;

        public getCategoryListQueryHandler(IMapper mapper, IRepository<Category> categoryrepository)
        {
            _mapper = mapper;
            _categoryrepository = categoryrepository;
        }
        public async Task<List<CategoryDto>> Handle(getCategoryListQuery request, CancellationToken cancellationToken)
        {

            var categoryList = await _categoryrepository.ListAllAsync();
            return _mapper.Map<List<CategoryDto>>(categoryList);


        }
    }
}
