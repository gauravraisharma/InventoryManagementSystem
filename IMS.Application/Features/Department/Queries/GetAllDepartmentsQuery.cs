using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.DepartmentDTOs;
using IMS.Core.RequestDto.Product;
using IMS.Infrastructure.Interface.Department;
using IMS.Infrastructure.Interface.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Department.Queries
{
    public class GetAllDepartmentsQuery : IRequest<GenericBaseResult<List<GetDepartmentRequestDto>>>
    {
    }

   

    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, GenericBaseResult<List<GetDepartmentRequestDto>>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<GenericBaseResult<List<GetDepartmentRequestDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetAllDepartmentsAsync();
            return department;
        }
    }
}
