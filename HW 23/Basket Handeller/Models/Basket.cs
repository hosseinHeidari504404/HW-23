namespace HW_23.Basket_Handeller.Models
{
    public class Basket
    {
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public decimal TotalPrice => BasketItems.Sum(b => b.Price);
    }
}
