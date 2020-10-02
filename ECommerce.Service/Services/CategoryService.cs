using ECommerce.Data.Context;
using ECommerce.Service.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Service.Services
{
  public  class CategoryService
    {
        private readonly ECommerceContext _context;
        public CategoryService(ECommerceContext context)
        {
            _context = context;
        }

        public List<CategoryResponse> GetCategories()
        {
             var categories =  _context.Category.ToList().Select(x => new CategoryResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return categories;
        }

     
    }
}
