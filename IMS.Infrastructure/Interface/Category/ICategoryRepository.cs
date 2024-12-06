using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.CategoryDTOs;
using IMS.Core.RequestDto.DepartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Interface.Category
{
    public interface ICategoryRepository
    {
        Task<GenericBaseResult<List<GetCategoryRequestDto>>> GetAllCategoriesAsync();
    }
}
