using IMS.Core.Common.Entities;
using IMS.Core.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class Orders : BaseAuditableEntity
{
    public string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; } 
    public DateTime? ShipmentDate { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string ProductDetailsJson { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual ApplicationUser Customer { get; set; }

    [NotMapped]
    public List<OrderProductDetails> ProductDetails
    {
        get => string.IsNullOrEmpty(ProductDetailsJson)
            ? new List<OrderProductDetails>()
            : JsonSerializer.Deserialize<List<OrderProductDetails>>(ProductDetailsJson);
        set => ProductDetailsJson = JsonSerializer.Serialize(value);
    }
}
