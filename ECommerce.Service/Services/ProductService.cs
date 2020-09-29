using ECommerce.Data.Context;
using ECommerce.Data.Entities;
using ECommerce.Service.Request;
using ECommerce.Service.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ECommerce.Service.Services
{
    public class ProductService
    {
        private readonly ECommerceContext _context;
        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        public List<ProductResponse> GetAll()
        {
            var products = _context.Product.Select(x => new ProductResponse()
            {

                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                UnitPrice = x.UnitPrice,
                StockCount = x.StockCount
            }).ToList();

            return products;
        }

        public ProductResponse Get(int id)
        {
            var productEntity = _context.Product.FirstOrDefault(x => x.Id == id);

            if (productEntity == null)
            {
                return null;
            }
            return new ProductResponse
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Brand = productEntity.Brand,
                UnitPrice = productEntity.UnitPrice,
                StockCount = productEntity.StockCount,


            };

        }

        public List<ProductResponse> Query(ProductQueryRequest request)
        {
            return _context.Product.Where(x => x.Id == request.Id || x.Brand == request.Brand)
                .ToList()
                .Select(e => new ProductResponse() //like models
                {
                    Id = e.Id,
                    Name = e.Name,
                    Brand = e.Brand,
                    UnitPrice = e.UnitPrice,
                    StockCount = e.StockCount,

                }).ToList();

        }

        public List<ProductResponse> GetProductByCategory(int categoryId)
        {
            var query = _context.Product.Join(_context.Category,
                product => product.CategoryId,
                category => category.Id,
                (product, category) => new { product, CategoryId = category.Id })
                .Where(query => query.CategoryId == categoryId)
                .ToList();

            return query.Select(x => new ProductResponse
            {
                Id = x.product.Id,
                Brand = x.product.Brand,
                UnitPrice = x.product.UnitPrice,
                StockCount = x.product.StockCount,
                Name = x.product.Name
            }).ToList();
        }

        public int Update(ProductUpdateRequest product)
        {
            var productEntity = _context.Product.FirstOrDefault(x => x.Id == product.Id);

            if (productEntity == null)
            {
                return -1;
            }

            productEntity.StockCount = product.StockCount;
            productEntity.UnitPrice = product.UnitPrice;

            _context.Product.Update(productEntity);
            return _context.SaveChanges();

            //return new ProductResponse
            //{
            //    Id = productEntity.Id,
            //    Brand = productEntity.Brand,
            //    UnitPrice = productEntity.UnitPrice,
            //    StockCount = productEntity.StockCount,
            //    Name = productEntity.Name
            //};
        }

        public int Create(ProductCreateRequest request)
        {
            Product product = new Product
            {
                
                Name = request.Name,
                Brand = request.Brand,
                StockCount = request.StockCount,
                UnitPrice = request.UnitPrice
            };

            _context.Product.Add(product);
            return _context.SaveChanges();

        }

        public int Delete(int Id)
        {
            var product = _context.Product.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return -1;
            }

            _context.Product.Remove(product);

            return _context.SaveChanges();
        }
    }
}
