using IMS.Shared.Common;
using IMS.Shared.RequestDto.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Shared.Interface.Category
{
    public interface ICategoryService
    {
        Task<ApiResponse<List<GetAllCategoryDto>>> GetAllCategoryAsync();
    }
}
