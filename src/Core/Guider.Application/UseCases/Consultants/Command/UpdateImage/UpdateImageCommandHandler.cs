using FluentValidation;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.UpdateImage
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateConsultantImageCommand, BaseResponse<string>>
    {
        private readonly IImageService _imageService;
        private readonly IValidator<UpdateConsultantImageCommand> _validator;
        private readonly IConsultantRepository _consultantRepository;

        public UpdateImageCommandHandler(IImageService imageService,
                                         IValidator<UpdateConsultantImageCommand> validator,
                                         IConsultantRepository consultantRepository)
        {
            _imageService = imageService;
            _validator = validator;
            _consultantRepository = consultantRepository;
        }
        public async Task<BaseResponse<string>> Handle(UpdateConsultantImageCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _consultantRepository.GetByIdAsync(request.Id);

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var imagePath = await _imageService.SaveImageAsync(request.Image, consultant);

            if (string.IsNullOrEmpty(imagePath))
                throw new Exceptions.BadRequestException("Photo upload failed!");

            consultant.Image = imagePath;
            bool updated = await _consultantRepository.UpdateAsync(consultant);
            var response = new BaseResponse<string>();

            if (updated)
            {
                response.Message = "Consultant image uloaded successfully.";
                response.Result = consultant.Image;
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

