using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common.ResponseModel
{
    public class ResponseCode
    {
        public static int BadRequest = 400;
        public static int ServerError = 500;
        public static int Ok = 200;
        public static int NotFound = 404;
        public static int Success = 200;
    }
}
