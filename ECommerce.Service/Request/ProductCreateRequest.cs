using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Request
{
  public  class ProductCreateRequest
    {

      

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }

        public int CategoryId { get; set; }
    }
}
