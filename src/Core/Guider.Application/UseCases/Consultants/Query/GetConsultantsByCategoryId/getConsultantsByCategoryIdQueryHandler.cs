using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantsByCategoryId
{
    public class getConsultantsByCategoryIdQueryHandler : IRequestHandler<getConsultantsByCategoryIdQuery, PaginatedList<ConsultantDto, Consultant>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        public getConsultantsByCategoryIdQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }
        public async Task<PaginatedList<ConsultantDto, Consultant>> Handle(getConsultantsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.getConsultantsbyCategoryId(request.categoryId);
            var paginatedList = await PaginatedList<ConsultantDto, Consultant>.CreateAsync(consultants, _mapper, request.Page, request.PageSize);
            return paginatedList;

        }
    }
}
