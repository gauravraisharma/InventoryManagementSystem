using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common.ResponseModel
{
    public class ResponseMessage
    {
        public const string RecordUpdated = "Record Updated Successfully";
        public const string RecordSaved = "Record Saved Successfully";
        public const string NotFound = "No Record Found";
        public const string Success = " Data Fetched Successfully";
        public const string ValidUser = "Valid User";
        public const string Error = "Some internal error occured";
        public const string UserExist = "UserName Already Exists";
    }
}
