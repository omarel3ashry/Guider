using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.CreateConsultant
{
    public class CreateConsultantCommandHandler : IRequestHandler<CreateConsultantCommand, ConsultantCreateOrUpdateDto>
    {
        private readonly IMapper _mapper;
        private readonly IConsultantRepository _consultantRepository;
        private readonly IValidator<CreateConsultantCommand> _validator;
        private readonly IRepository<SubCategory> _repository;
        private readonly IRepository<User> _userRepo;

        public CreateConsultantCommandHandler(IMapper mapper, IConsultantRepository consultantRepository,IValidator<CreateConsultantCommand> validator,IRepository<SubCategory> Subrepository,IRepository<User> userRepo)
        {
            _mapper = mapper;
            _consultantRepository = consultantRepository;
            _validator = validator;
           _repository = Subrepository;
            _userRepo = userRepo;
        }
        public async Task<ConsultantCreateOrUpdateDto> Handle(CreateConsultantCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var user = await _userRepo.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found.");
            }

                // Check if the subcategory exists
                var subCategory = await _repository.GetByIdAsync(request.SubCategoryId);
            if (subCategory == null)
            {
                throw new NotFoundException($"SubCategory with ID {request.SubCategoryId} not found.");
            }
            var consultant = _mapper.Map<Consultant>(request);
            consultant.User = user; // Ensure the User is set
            consultant.SubCategory = subCategory; // Ensure the SubCategory is set

            // Add the consultant to the database
            await _consultantRepository.AddAsync(consultant);
            

            // Map the Consultant entity to the ConsultantDto
            var consultantDto = _mapper.Map<ConsultantCreateOrUpdateDto>(consultant);

            return consultantDto;

        }
    }
}
