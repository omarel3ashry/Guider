using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetFiltered
{
    public class GetFilteredQueryHandler : IRequestHandler<GetFilteredQuery, BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>>
    {
        private readonly IConsultantRepository _consultantRepo;
        private readonly IMapper _mapper;

        public GetFilteredQueryHandler(IConsultantRepository consultantRepo, IMapper mapper)
        {
            _consultantRepo = consultantRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>> Handle(GetFilteredQuery request, CancellationToken cancellationToken)
        {
            var query = _consultantRepo.GetAllByFilters(request.CategoryId, request.SubCategoryId, request.SortByPrice, request.SortAsc);
            var filteredList = await PaginatedList<FilteredConsultantDto, Consultant>.CreateWithProjectToAsync(query, _mapper, request.Page, request.PageSize);
            return new BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>() { Message = "Successfully retrieved.", Result = filteredList };
        }
    }
}
