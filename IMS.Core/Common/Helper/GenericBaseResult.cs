using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common.Helper
{
    public class GenericBaseResult<TModel> : BaseResult
    {
        public TModel Result { get; set; }

        public GenericBaseResult(TModel model)
        {
            Result = model;
        }
    }

}
