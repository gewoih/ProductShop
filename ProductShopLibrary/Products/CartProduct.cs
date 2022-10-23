namespace ProductShopLibrary.Products
{
    public class CartProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount => Product.Price * Quantity;

        public CartProduct(Product product)
        {
            Product = product;
            Quantity = 1;
        }

        public void AddUnit()
        {
            Quantity++;
        }

        public void SubtractUnit()
        {
            if (Quantity > 0)
                Quantity--;
        }
    }
}
