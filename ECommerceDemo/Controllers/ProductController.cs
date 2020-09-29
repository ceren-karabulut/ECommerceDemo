using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Service.Request;
using ECommerce.Service.Responce;
using ECommerce.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDemo.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<ProductResponse> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] //for give data from route 
        public IActionResult Get([FromRoute] int id)
        {   
            var product= _service.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public List<ProductResponse> Query([FromBody] ProductQueryRequest request)
        {
            return _service.Query(request);
        }

        [HttpGet("{id}")]
        public List<ProductResponse> GetByCategory(int id)
        {
            return _service.GetProductByCategory(id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductUpdateRequest product)
        {
            var affectedRowCount = _service.Update(product);
            if (affectedRowCount > 0)
            {
                return Ok();
            }

            else if (affectedRowCount == -1)
            {
                return NotFound();
            }
            return UnprocessableEntity();
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductCreateRequest request)
        {
            var affectedRowCount = _service.Create(request);
            if (affectedRowCount>0)
            {
                return Ok();
            }else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {   
            var affectedRowCount= _service.Delete(id);
            if (affectedRowCount > 0)
            {
                return Ok();
            }
            else if (affectedRowCount == -1)
            {
                return NotFound("Product has not deleted");
            }
            return UnprocessableEntity();

        }
    }
}
