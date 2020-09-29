using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Entities
{
   public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }

        public int CategoryId { get; set; }
    }
}
