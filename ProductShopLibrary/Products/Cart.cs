using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopLibrary.Products
{
    public class Cart
    {
        public List<CartProduct> Products { get; set; }
        public decimal TotalAmount => Products.Sum(p => p.TotalAmount);

        public Cart()
        {
            Products = new List<CartProduct>();
        }
    }
}
