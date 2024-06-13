using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, BaseResponse<string>>
    {
        private readonly IValidator<UpdateImageCommand> _validator;
        private readonly IConsultantRepository _consultantRepository;

        public UpdateImageCommandHandler(IValidator<UpdateImageCommand> validator,IConsultantRepository consultantRepository)
        {
            _validator = validator;
            _consultantRepository = consultantRepository;
        }
        public async Task<BaseResponse<string>> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {

            var ConsultantToUpdate = await _consultantRepository.GetByIdAsync(request.Id);
           
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            ConsultantToUpdate.Image = request.Image;
            bool updated = await _consultantRepository.UpdateAsync(ConsultantToUpdate);
            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "consultant image uloaded successfully.";
                response.Result = ConsultantToUpdate.Image;
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to update the image!";
            }
            return response;
        }
    }
    }

