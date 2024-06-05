using AutoMapper;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant
{
    public class ConsultantProfiles:Profile
    {
        public ConsultantProfiles()
        {
            CreateMap<Consultant,ConsultantDetailsVM>();
            CreateMap<SubCategory,SubCategoryDTO>();
            CreateMap<Consultant,ConsultantListVM>();
            CreateMap<SubCategory,SubCategoryDto>();
        }
    }
}
