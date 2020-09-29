using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.UI.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCount { get; set; }
    }
}
