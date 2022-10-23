using ProductShopLibrary.Products;

namespace ProductShopLibrary.Purchases
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Cart ProductCart { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }
}
