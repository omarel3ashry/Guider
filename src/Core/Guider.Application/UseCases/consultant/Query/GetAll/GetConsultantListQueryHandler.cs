using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Query.GetAll
{
    public class GetConsultantListQueryHandler : IRequestHandler<GetConsultantListQuery, List<ConsultantListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Consultant> _repository;
        private readonly IRepository<Category> _categoryrepository;

        public GetConsultantListQueryHandler(IMapper mapper,IRepository<Consultant> repository,IRepository<Category> Categoryrepository)
        {
            _mapper = mapper;
            _repository = repository;
            _categoryrepository = Categoryrepository;
        }
        public async Task<List<ConsultantListVM>> Handle(GetConsultantListQuery request, CancellationToken cancellationToken)
        {
            var AllConsultant= (await _repository.ListAllAsync()).OrderBy(x => x.Id).ToList();
            var ConsultantToReturn=_mapper.Map<List<ConsultantListVM>>(AllConsultant);
            //need to adjust after including
            return ConsultantToReturn;


        }
    }
}
