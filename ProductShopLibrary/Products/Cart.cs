namespace ProductShopLibrary.Products
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<CartProduct> Products { get; set; }
        public decimal TotalAmount => Products.Sum(p => p.TotalAmount);

        public Cart()
        {
            Products = new List<CartProduct>();
        }

        public void AddProduct(Product product)
        {
            CartProduct productInCart = Products.FirstOrDefault(p => p.Product.Id == product.Id);

            if (productInCart == null)
                Products.Add(new CartProduct() { Product = product });
            else
                productInCart.AddUnit();
        }
    }
}
