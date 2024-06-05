using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.consultant.Query.GetDetails
{
    public class GetConsultantDetailsQueryHandler : IRequestHandler<GetConsultantDetailsQuery, ConsultantDetailsVM>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Consultant> _repository;
        private readonly IRepository<SubCategory> _subCategoryRepo;

        public GetConsultantDetailsQueryHandler(IMapper mapper, IRepository<Consultant> repository,IRepository<SubCategory>SubCategoryRepo
            )
        {
            _mapper = mapper;
            _repository = repository;
            _subCategoryRepo = SubCategoryRepo;
        }
        public async Task<ConsultantDetailsVM>Handle(GetConsultantDetailsQuery request, CancellationToken cancellationToken)
        {
            var consultant = await _repository.GetByIdAsync(request.Id);
            var ConsultantToReturn = _mapper.Map<ConsultantDetailsVM>(consultant);
            var SubCategoryToReturn = await _subCategoryRepo.GetByIdAsync(consultant.SubCategoryId);
            ConsultantToReturn.SubCategory = _mapper.Map<SubCategoryDTO>(SubCategoryToReturn);
            return ConsultantToReturn;
        }
    }
}
