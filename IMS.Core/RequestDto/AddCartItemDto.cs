namespace IMS.Core.RequestDto
{
    public class AddCartItemDto
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string ProductSizeName { get; set; }
        public int Quantity { get; set; }
    }
}
