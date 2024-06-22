using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.SubCategories.Query.getSubCategoryByCategoryId
{
    public class getSubCategoryByCategoryIdQueryHandler : IRequestHandler<getSubCategoryByCategoryIdQuery, List<subCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryRepository _subCategoryRepository;
        public getSubCategoryByCategoryIdQueryHandler(IMapper mapper, ISubCategoryRepository subCategoryRepository)
        {
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;

        }
        public async Task<List<subCategoryDto>> Handle(getSubCategoryByCategoryIdQuery request, CancellationToken cancellationToken)
        {

            var subCategoryList = await _subCategoryRepository.getbyCategoryId(request.categoryId);

            return _mapper.Map<List<subCategoryDto>>(subCategoryList);

        }
    }
}
