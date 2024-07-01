using Guider.Application.Contracts.Persistence;
using Guider.Application.Responses;
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

        public VerifyConsultantCommandHandler(IConsultantRepository repository)
        {
            _repository = repository;
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

            return new BaseResponse { Success = true };

        }
    }
}
