using IMS.Core.Common.Helper;
using IMS.Core.RequestDto.CategoryDTOs;
using IMS.Core.RequestDto.DepartmentDTOs;
using IMS.Infrastructure.Interface.Category;
using IMS.Infrastructure.Interface.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Application.Features.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<GenericBaseResult<List<GetCategoryRequestDto>>>
    {
    }
   



    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, GenericBaseResult<List<GetCategoryRequestDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GenericBaseResult<List<GetCategoryRequestDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var products = await _categoryRepository.GetAllCategoriesAsync();
            return products;
        }
    }
}
