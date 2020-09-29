using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Models.Requests
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }


        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }
    }
}
