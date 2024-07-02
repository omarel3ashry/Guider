using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
using Guider.Domain.Entities;
using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Command.VerifyConsultant
{
    
    public class VerifyConsultantCommandHandler : IRequestHandler<VerifyConsultantCommand, BaseResponse>
    {
        private readonly IConsultantRepository _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IMailFactory _mailFactory;
        private readonly IMailService _mailService;

        public VerifyConsultantCommandHandler(IConsultantRepository repository, IMailFactory mailFactory, IMailService mailService, IRepository<User> userRepository)
        {
            _repository = repository;
            _mailFactory = mailFactory;
            _mailService = mailService;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse> Handle(VerifyConsultantCommand request, CancellationToken cancellationToken)
        {
            var con = await  _repository.GetByIdAsync(request.Id);

            if (con == null)
                throw new Exceptions.BadRequestException("Invalid Consultant Id");

            con.IsVerified = true;
            var res = await _repository.UpdateAsync(con);
            if(!res)
                throw new Exceptions.BadRequestException("Can not Verified Consultant");

            var user = await _userRepository.GetByIdAsync(con.UserId);
            if (user == null)
                throw new Exceptions.BadRequestException("Can not Verified Consultant");

            var mes = _mailFactory.GenerateMailMssage(MailType.ConfirmConsultant, user);
            await _mailService.SendMailAsync(mes);

            return new BaseResponse { Success = true };

        }
    }
}
