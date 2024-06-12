using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.UseCases.consultant.Command.CreateConsultant;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.UpdateConsultant
{
    public class UpdateConsultantCommandHandler : IRequestHandler<UpdateConsultantCommand, ConsultantCreateOrUpdateDto>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IValidator<UpdateConsultantCommand> _validator;

        public UpdateConsultantCommandHandler(IMapper mapper,IConsultantRepository consultantRepository,IValidator<UpdateConsultantCommand> validator)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            _validator = validator;
        }
        public async  Task<ConsultantCreateOrUpdateDto> Handle(UpdateConsultantCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            // Get the existing consultant
            var consultant = await _consultantRepository.GetConsultantWithUserByIdAsync(request.ConsultantId);
            if (consultant == null)
            {
                throw new NotFoundException($"Consultant with ID {request.ConsultantId} not found.");
            }

            // Update the consultant properties
            consultant.HourlyRate = request.HourlyRate;
            consultant.Bio = request.Bio;

            // Save the changes
            await _consultantRepository.UpdateAsync(consultant);

            // Return the updated consultant
            return _mapper.Map<ConsultantCreateOrUpdateDto>(consultant);
        }


    }
}
