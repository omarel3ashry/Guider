using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, BaseResponse<string>>
    {
        private readonly IValidator<UpdateImageCommand> _validator;
        private readonly IClientRepository _clientRepository;
        

        public UpdateImageCommandHandler(IValidator<UpdateImageCommand> validator,IClientRepository clientRepository)
        {
            _validator = validator;
            _clientRepository = clientRepository;
            
        }
        public async Task<BaseResponse<string>> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {

            var ClientToUpdate = await _clientRepository.GetByIdAsync(request.Id);
           
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            ClientToUpdate.Image = request.Image;
            bool updated = await _clientRepository.UpdateAsync(ClientToUpdate);
            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "client image uloaded successfully.";
                response.Result = ClientToUpdate.Image;
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

