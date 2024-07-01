using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetFilteredByName
{
    internal class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>>
    {
        private readonly IConsultantRepository _consultantRepo;
        private readonly IMapper _mapper;

        public GetByNameQueryHandler(IConsultantRepository consultantRepo, IMapper mapper)
        {
            _consultantRepo = consultantRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            var query = _consultantRepo.GetAllByName(request.Name);
            var filteredList = await PaginatedList<FilteredConsultantDto, Consultant>.CreateWithProjectToAsync(query, _mapper, request.Page, request.PageSize);
            return new BaseResponse<PaginatedList<FilteredConsultantDto, Consultant>>() { Message = "Successfully retrieved.", Result = filteredList };
        }
    }
}

