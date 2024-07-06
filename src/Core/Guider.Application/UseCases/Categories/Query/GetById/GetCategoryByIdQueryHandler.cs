using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Categories.Query.GetById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, BaseResponse<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepo;

        public GetCategoryByIdQueryHandler(IMapper mapper,
                                           ICategoryRepository categoryRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<BaseResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepo.GetWithSubCategoriesAsync(request.Id);

            if (category == null)
            {
                throw new Exceptions.NotFoundException("Category not found!");
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return new BaseResponse<CategoryDto>() { Message = "Successful.", Result = categoryDto };
        }
    }
}
