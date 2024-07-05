using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.UpdateConsultant
{
    public class UpdateConsultantCommandHandler : IRequestHandler<UpdateConsultantCommand, BaseResponse<ConsultantUpdateDto>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IValidator<UpdateConsultantCommand> _validator;

        public UpdateConsultantCommandHandler(IMapper mapper, IConsultantRepository consultantRepository, IValidator<UpdateConsultantCommand> validator)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            _validator = validator;
        }
        public async Task<BaseResponse<ConsultantUpdateDto>> Handle(UpdateConsultantCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var consultant = await _consultantRepository.GetWithUserAsync(request.id);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with ID {request.id} not found.");
            }

            consultant.HourlyRate = request.HourlyRate;
            consultant.Bio = request.Bio;
            consultant.User.LastName = request.lastName;
            consultant.User.FirstName = request.firstName;
            consultant.User.Email = request.email;

            await _consultantRepository.UpdateAsync(consultant);


            var ConsultantToReturn = _mapper.Map<ConsultantUpdateDto>(consultant);
            var response = new BaseResponse<ConsultantUpdateDto>();
            response.Result = ConsultantToReturn;
            response.Success = ConsultantToReturn != null;

            if (!response.Success)
            {
                response.Message = "unable to update.";
            }

            return response;
        }


    }
}
