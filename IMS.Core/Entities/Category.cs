using IMS.Core.Common.Entities;

namespace IMS.Core.Entities
{
    public class Category: BaseAuditableEntity
    {
       
        public string Name { get; set; }
        public ICollection<CategoryProductMapping> CategoryProductMappings { get; set; } = new List<CategoryProductMapping>();
    }
}
    