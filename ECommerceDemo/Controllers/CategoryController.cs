using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Service.Responce;
using ECommerce.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>categories</returns>
        [HttpGet]
        public List<CategoryResponse> GetAll()
        {
            return _service.GetCategories();
        }
    }
}
