using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.consultant.Query.GetDetails
{
    public class GetConsultantDetailsQueryHandler : IRequestHandler<GetConsultantDetailsQuery, ConsultantDetailsVM>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
       
        public GetConsultantDetailsQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            
        }
        public async Task<ConsultantDetailsVM>Handle(GetConsultantDetailsQuery request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetConsultantWithsubCategoryAndSchedule(request.Id);
            var ConsultantToReturn = _mapper.Map<ConsultantDetailsVM>(consultant);
            
            return ConsultantToReturn;
        }
    }
}
