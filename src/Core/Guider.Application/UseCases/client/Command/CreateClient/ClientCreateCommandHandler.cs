using AutoMapper;
using FluentValidation;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.CreateClient
{
    public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, ClientCreateDto>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IValidator<ClientCreateCommand> _validator;
        private readonly IRepository<User> _repository;

        public ClientCreateCommandHandler(IMapper mapper,IClientRepository clientRepository, IValidator<ClientCreateCommand> validator,IRepository<User> repository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _validator = validator;
            _repository = repository;
        }

        public async  Task<ClientCreateDto> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            var user = await _repository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException($"User with ID {request.UserId} not found.");
            }
            var client = _mapper.Map<Client>(request);
            
            await _clientRepository.AddAsync(client);
            return _mapper.Map<ClientCreateDto>(client);
        }
    }
}
