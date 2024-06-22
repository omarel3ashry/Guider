﻿using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.GetAll
{
    public class GetConsultantListQueryHandler : IRequestHandler<GetConsultantListQuery, BaseResponse<List<ConsultantVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;


        public GetConsultantListQueryHandler(IMapper mapper, IConsultantRepository consultantRepository)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;

        }


        public async Task<BaseResponse<List<ConsultantVM>>> Handle(GetConsultantListQuery request, CancellationToken cancellationToken)
        {
            var allConsultants = await _consultantRepository.GetConsultantsWithsubCategoryAndSchedule();
            var consultantToReturn = _mapper.Map<List<ConsultantVM>>(allConsultants);
            var response = new BaseResponse<List<ConsultantVM>>();
            response.Result = consultantToReturn;
            response.Success = consultantToReturn != null; // Concise assignment

            if (!response.Success) // More descriptive check
            {
                response.Message = "No consultants found."; // Or a more specific message
            }

            return response;


        }
    }
}