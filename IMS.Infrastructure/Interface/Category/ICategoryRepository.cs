using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.CategoryDTOs;

namespace IMS.Infrastructure.Interface.Category
{
    public interface ICategoryRepository
    {
        Task<GenericBaseResult<List<GetCategoryRequestDto>>> GetAllCategoriesAsync();
    }
}
