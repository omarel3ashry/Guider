using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Users.Command.ConsultantRegister
{
    public class ConsultantRegisterCommandHandler : IRequestHandler<ConsultantRegisterCommand, AuthenticationResponse>
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IRegisterUserRepository<Consultant> _userRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IValidator<ConsultantRegisterCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public ConsultantRegisterCommandHandler(IConsultantRepository consultantRepository,
                                                IRegisterUserRepository<Consultant> userRepository,
                                                IValidator<ConsultantRegisterCommand> validator,
                                                IMapper mapper, IImageService imageService,
                                                IAttachmentRepository attachmentRepository)

        {
            _consultantRepository = consultantRepository;
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            _imageService = imageService;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<AuthenticationResponse> Handle(ConsultantRegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var user = _mapper.Map<User>(request);
            var result = await _userRepository.RegisterAsync(user, request.Password);

            if (!result.Success)
                return result;
            var consultant = _mapper.Map<Consultant>(request);
            consultant.UserId = result.Id;

            bool created = await _consultantRepository.AddAsync(consultant);
            if (!created)
                throw new Exceptions.BadRequestException("Error in create Consultant");

            var urls = await _imageService.SaveImages(request.Files,consultant);
            if (urls.Count == 0)
                throw new Exceptions.BadRequestException("Error in save Attachments to server");

            List<Attachment> attachments = new List<Attachment>();
            foreach ( var url in urls)
            {
                attachments.Add(new Attachment {ImageUrl = url, ConsultantId = consultant.Id });
            }

            var res = await _attachmentRepository.AddAttachmentsAsync(attachments);
            if (!res)
                throw new Exceptions.BadRequestException("Error in save Attachments to database");

            return result;
        }
    }
}
