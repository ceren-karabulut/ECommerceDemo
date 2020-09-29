using AutoMapper;
using ECommerce.UI.Models.Responses;
using ECommerce.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryResponse, CategoryViewModel>();
        }
    }
}
