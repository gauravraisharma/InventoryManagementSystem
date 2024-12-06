using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.CategoryDTOs;
using IMS.Core.RequestDto.DepartmentDTOs;
using IMS.Core.RequestDto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Interface.Department
{
    public interface IDepartmentRepository
    {
        Task<GenericBaseResult<List<GetDepartmentRequestDto>>> GetAllDepartmentsAsync();
    }
}

