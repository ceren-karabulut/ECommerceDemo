using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Models.Requests
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }

        public int CategoryId { get; set; }
    }
}
