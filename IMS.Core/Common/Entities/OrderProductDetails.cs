namespace IMS.Core.Common.Entities
{
    public class OrderProductDetails
    {
        public string ProductId { get; set; }
        public string? Title { get; set; }
        public string? ItemSize { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public decimal UnitAmount { get; set; }
    }

}
