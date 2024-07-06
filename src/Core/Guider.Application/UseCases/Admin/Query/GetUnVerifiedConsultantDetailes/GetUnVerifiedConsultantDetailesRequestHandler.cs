using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes
{
    public class GetUnVerifiedConsultantDetailesRequestHandler : IRequestHandler<GetUnVerifiedConsultantDetailesRequest, BaseResponse<ConsultantDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;

        public GetUnVerifiedConsultantDetailesRequestHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
        }

        public async Task<BaseResponse<ConsultantDetailsDto>> Handle(GetUnVerifiedConsultantDetailesRequest request, CancellationToken cancellationToken)
        {
            var con = await _consultantRepository.GetConsultantWithsubCategoryUserAndAttachmentsById(request.Id);
            var dto = _mapper.Map<ConsultantDetailsDto>(con);
            return new BaseResponse<ConsultantDetailsDto> { Success = true, Result = dto };
        }
    }
}
