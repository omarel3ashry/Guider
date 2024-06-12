using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Query.GetAll
{
    public class GetConsultantListQueryHandler : IRequestHandler<GetConsultantListQuery, List<ConsultantListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
       

        public GetConsultantListQueryHandler(IMapper mapper,IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
          
        }
        public async Task<List<ConsultantListVM>> Handle(GetConsultantListQuery request, CancellationToken cancellationToken)
        {
            var AllConsultant = await _consultantRepository.GetConsultantsWithsubCategoryAndSchedule();
            var ConsultantToReturn=_mapper.Map<List<ConsultantListVM>>(AllConsultant);
            
           
            return ConsultantToReturn;


        }
    }
}
