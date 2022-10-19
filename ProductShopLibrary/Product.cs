﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public byte[] Image { get; set; }
    }
}
