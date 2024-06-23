using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Application.UseCases.Consultants.Query.GetConsultantsByCategoryId;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Query.GetConsultantBySubCategoryId
{
    public class GetConsultantBySubCategoryIdQueryHandler : IRequestHandler<GetConsultantBySubCategoryIdQuery, PaginatedList<ConsultantDto, Consultant>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        public GetConsultantBySubCategoryIdQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository=consultantRepository;
        }
        public async Task<PaginatedList<ConsultantDto, Consultant>> Handle(GetConsultantBySubCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var consultants = await _consultantRepository.getConsultantsbySubCategoryId(request.SubCategoryId);
            var paginatedList = await PaginatedList<ConsultantDto, Consultant>.CreateAsync(consultants, _mapper, request.Page, request.PageSize);
            return paginatedList;
        }
    }
}
