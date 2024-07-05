using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetDetails
{
    public class GetConsultantDetailsQueryHandler : IRequestHandler<GetConsultantDetailsQuery, BaseResponse<ConsultantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;

        public GetConsultantDetailsQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;

        }
        public async Task<BaseResponse<ConsultantDto>> Handle(GetConsultantDetailsQuery request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetWithIncludesAsync(request.Id);

            var ConsultantToReturn = _mapper.Map<ConsultantDto>(consultant);

            var response = new BaseResponse<ConsultantDto>();
            response.Result = ConsultantToReturn;
            response.Success = ConsultantToReturn != null;

            if (!response.Success)
            {
                response.Message = "No consultant found.";
            }

            return response;
        }
    }
}
