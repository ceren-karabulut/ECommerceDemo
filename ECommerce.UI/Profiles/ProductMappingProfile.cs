using AutoMapper;
using ECommerce.UI.Models.Requests;
using ECommerce.UI.Models.Responses;
using ECommerce.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductResponse, ProductViewModel>();
            CreateMap<ProductViewModel, ProductResponse>();
            CreateMap<ProductViewModel, ProductUpdateRequest>();

            CreateMap<ProductAddViewModel, ProductCreateRequest>();
            CreateMap<ProductCreateRequest, ProductResponse>();
        }
    }
}
