using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Service.Request
{
   public class ProductUpdateRequest
    {
        public int Id { get; set; }


        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }
    }
}
