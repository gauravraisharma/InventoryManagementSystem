using IMS.Core.Common.Helper;
using IMS.Core.Common.ResponseModel;
using IMS.Core.RequestDto.DepartmentDTOs;
using IMS.Core.RequestDto.Product;
using IMS.Infrastructure.Interface.Department;
using IMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace IMS.Infrastructure.Services.Department
{
    public class DepartmentRepository:IDepartmentRepository
    {

        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<GenericBaseResult<List<GetDepartmentRequestDto>>> GetAllDepartmentsAsync()
        {
            try
            {
                var response = new GenericBaseResult<List<GetDepartmentRequestDto>>(new List<GetDepartmentRequestDto>());

                var department = await (from p in context.Departments
                                      select new GetDepartmentRequestDto
                                      {
                                          Name = p.Name,
                                          DepartmentId= p.Id
                                      
                                      }).ToListAsync();

                response.Message = ResponseMessage.Success;
                response.Result = department;
                return response;
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<GetDepartmentRequestDto>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }
    }
}
