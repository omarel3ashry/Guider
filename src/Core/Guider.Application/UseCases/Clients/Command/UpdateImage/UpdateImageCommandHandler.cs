using FluentValidation;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Clients.Command.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateClientImageCommand, BaseResponse<string>>
    {
        private readonly IImageService _imageService;
        private readonly IValidator<UpdateClientImageCommand> _validator;
        private readonly IClientRepository _clientRepository;


        public UpdateImageCommandHandler(IImageService imageService,
                                         IClientRepository clientRepository,
                                         IValidator<UpdateClientImageCommand> validator
            )
        {
            _imageService = imageService;
            _validator = validator;
            _clientRepository = clientRepository;

        }
        public async Task<BaseResponse<string>> Handle(UpdateClientImageCommand request, CancellationToken cancellationToken)
        {

            var client = await _clientRepository.GetByIdAsync(request.Id);

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var imagePath = await _imageService.SaveImageAsync(request.Image, client);

            if (string.IsNullOrEmpty(imagePath))
                throw new Exceptions.BadRequestException("Photo upload failed!");

            client.Image = imagePath;
            bool updated = await _clientRepository.UpdateAsync(client);
            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "client image uloaded successfully.";
                response.Result = client.Image;
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

