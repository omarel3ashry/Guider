﻿using AutoMapper;
using Guider.Application.UseCases.Consultants.ConsultantSearch.Query;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSearch
{
    public class ConsultantProfile:Profile
    {
        public ConsultantProfile()
        {
            CreateMap<Consultant, ConsultantSearchDto>()
               .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
               .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
               .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}