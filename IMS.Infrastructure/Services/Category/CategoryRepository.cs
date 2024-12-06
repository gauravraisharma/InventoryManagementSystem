using IMS.Core.Common.Helper;
using IMS.Core.Common.ResponseModel;
using IMS.Core.RequestDto.CategoryDTOs;
using IMS.Core.RequestDto.DepartmentDTOs;
using IMS.Infrastructure.Interface.Category;
using IMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace IMS.Infrastructure.Services.Category
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<GenericBaseResult<List<GetCategoryRequestDto>>> GetAllCategoriesAsync()
        {
            try
            {
                var response = new GenericBaseResult<List<GetCategoryRequestDto>>(new List<GetCategoryRequestDto>());

                var department = await (from p in context.Categories
                                        select new GetCategoryRequestDto
                                        {
                                            Name = p.Name,
                                            CategoryId = p.Id

                                        }).ToListAsync();

                response.Message = ResponseMessage.Success;
                response.Result = department;
                return response;
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<GetCategoryRequestDto>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }
    }
}
