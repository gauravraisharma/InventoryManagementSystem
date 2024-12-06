using IMS.Shared.Common;
using IMS.Shared.RequestDto.DepartmentDTOs;
using IMS.Shared.RequestDto.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Interface.Department
{
    public interface IDepartmentService
    {
        Task<ApiResponse<List<GetAllDepartmentDto>>> GetAllDepartmentAsync();
    }
}
