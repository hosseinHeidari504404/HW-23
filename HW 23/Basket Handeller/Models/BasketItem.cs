namespace HW_23.Basket_Handeller.Models
{
    public class BasketItem
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price => UnitPrice * Count;
    }
}
