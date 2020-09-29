
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Responce
{
  public  class ProductResponse
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }
        
    }
}
