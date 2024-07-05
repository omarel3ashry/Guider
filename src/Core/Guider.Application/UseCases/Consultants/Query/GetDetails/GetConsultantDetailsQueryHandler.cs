using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Application.UseCases.Consultants.Query.GetAll;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetDetails
{
    public class GetConsultantDetailsQueryHandler : IRequestHandler<GetConsultantDetailsQuery, BaseResponse<ConsultantVM>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;

        public GetConsultantDetailsQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;

        }
        public async Task<BaseResponse<ConsultantVM>> Handle(GetConsultantDetailsQuery request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetConsultantWithsubCategoryAndSchedule(request.Id);



            var ConsultantToReturn = _mapper.Map<ConsultantVM>(consultant);


            var response = new BaseResponse<ConsultantVM>();
            response.Result = ConsultantToReturn;
            response.Success = ConsultantToReturn != null; // Concise assignment

            if (!response.Success) // More descriptive check
            {
                response.Message = "No consultant found."; // Or a more specific message
            }

            return response;
        }


    }
}
