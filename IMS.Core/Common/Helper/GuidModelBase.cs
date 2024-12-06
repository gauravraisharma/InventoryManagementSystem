using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common.Helper
{
    public class GuidModelBase
    {
        [StringLength(36)]
        [Key]
        public string Id { get; set; }
        protected GuidModelBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
