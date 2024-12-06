using IMS.Core.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common.Entities
{
    public class BaseAuditableEntity: GuidModelBase, IAuditableEntity
    {
        public virtual DateTime? Created { get; set; }

        public virtual string? CreatedBy { get; set; }

        public virtual DateTime? LastModified { get; set; }

        public virtual string? LastModifiedBy { get; set; }
    }
    public interface IAuditableEntity
    {
        DateTime? Created { get; set; }

        string? CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string? LastModifiedBy { get; set; }
    }
}
