using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants
{
    
    public class GetUnVerifiedConsultantsRequestHandler : IRequestHandler<GetUnVerifiedConsultantsRequest, BaseResponse<List<ConsultantListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;

        public GetUnVerifiedConsultantsRequestHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }

        public async Task<BaseResponse<List<ConsultantListDto>>> Handle(GetUnVerifiedConsultantsRequest request, CancellationToken cancellationToken)
        {
            var entityList = await _consultantRepository.GetUnVerifiedConsultants();
            var list = _mapper.Map<List<ConsultantListDto>>(entityList);
            return new BaseResponse<List<ConsultantListDto>> { Success = true, Result = list };
        }
    }
}
