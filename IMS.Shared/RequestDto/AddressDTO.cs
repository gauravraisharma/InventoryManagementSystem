namespace IMS.Shared.RequestDto
{
    public class AddressDTO
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public string? Title { get; set; }
        public string? PinCode { get; set; }

    }
}
