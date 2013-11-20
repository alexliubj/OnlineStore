using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStoreDAL.Models
{
    public class ProductDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image1FileName { get; set; }
        public string Image2FileName { get; set; }
        public bool OnDepartmentPromotion { get; set; }
        public bool OnCatalogPromotion { get; set; }
    }
}
