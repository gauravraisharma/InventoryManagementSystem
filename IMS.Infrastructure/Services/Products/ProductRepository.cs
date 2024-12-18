using IMS.Core.RequestDto.Product;
using IMS.Infrastructure.Interface.Products;
using IMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMS.Core.Entities;
using IMS.Core.RequestDto.ProductDTOs;
using IMS.Core.Common.Helper;
using IMS.Core.Common.ResponseModel;
//using IMS.Core.Common.Enums;

namespace IMS.Infrastructure.Services.Product
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<GenericBaseResult<List<GetProductRequestDto>>> GetAllProductsAsync(string department = null, string category = null, string searchText = null, string sortBy = null)
        {
            try
            {
                var response = new GenericBaseResult<List<GetProductRequestDto>>(new List<GetProductRequestDto>());

                var query = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(department) && department != "all")
                {
                    query = query.Where(p => context.DepartmentProductMappings
                                    .Where(mapping => mapping.Department.Name == department)
                                    .Select(mapping => mapping.ProductId)
                                    .Contains(p.Id));
                }

                if (!string.IsNullOrEmpty(category) && category != "all")
                {
                    query = query.Where(p => context.CategoryProductMappings
                                    .Where(mapping => mapping.Category.Name == category)
                                    .Select(mapping => mapping.ProductId)
                                    .Contains(p.Id));
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(p => p.Title.Contains(searchText) || p.Description.Contains(searchText));
                }

                
                query = sortBy switch
                {
                    "newest" => query.OrderByDescending(p => p.Created),
                    "oldest" => query.OrderBy(p => p.Created),
                    _ => query
                };

                var products = await query.Select(p => new GetProductRequestDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    ProductCode = p.ProductCode,
                    DepartmentIds = context.DepartmentProductMappings
                                    .Where(mapping => mapping.ProductId == p.Id)
                                    .Select(mapping => mapping.DepartmentId)
                                    .ToList(),
                    DepartmentNames = context.DepartmentProductMappings
                                    .Where(mapping => mapping.ProductId == p.Id)
                                    .Select(mapping => mapping.Department.Name)
                                    .ToList(),
                    CategoryNames = context.CategoryProductMappings
                                    .Where(mapping => mapping.ProductId == p.Id)
                                    .Select(mapping => mapping.Category.Name)
                                    .ToList(),
                    CategoryIds = context.CategoryProductMappings
                                    .Where(mapping => mapping.ProductId == p.Id)
                                    .Select(mapping => mapping.CategoryId)
                                    .ToList(),
                    ProductImages = p.ProductImages.Select(i => i.Base64Image).ToList(),
                    ProductSizes = p.ProductSizes.Select(s => s.Size).ToList()
                }).ToListAsync();

                response.Message = ResponseMessage.Success;
                response.Result = products;
                return response;
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<List<GetProductRequestDto>>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }


        public async Task<GenericBaseResult<GetProductRequestDto>> GetProductByIdAsync(string productId)
        {
            try
            {

                var response = new GenericBaseResult<GetProductRequestDto>(null);

                // Fetch the product and its related categories
                var product = await (from p in context.Products
                                     join cpm in context.CategoryProductMappings on p.Id equals cpm.ProductId
                                     join de in context.DepartmentProductMappings on p.Id equals de.ProductId
                                     join c in context.Categories on cpm.CategoryId equals c.Id
                                     join d in context.Departments on de.DepartmentId equals d.Id
                                     where p.Id == productId
                                     select new GetProductRequestDto
                                     {
                                         Id = p.Id,
                                         Title = p.Title,
                                         Description = p.Description,
                                         UnitPrice = p.UnitPrice,
                                         UnitsInStock = p.UnitsInStock,
                                         ProductCode = p.ProductCode,
                                         //DepartmentName = p.Department,
                                         DepartmentIds = context.DepartmentProductMappings
                                             .Where(mapping => mapping.ProductId == p.Id)
                                             .Select(mapping => mapping.DepartmentId)
                                             .ToList(),
                                         DepartmentNames = context.DepartmentProductMappings
                                             .Where(mapping => mapping.ProductId == p.Id)
                                             .Select(mapping => mapping.Department.Name)
                                             .ToList(),
                                         CategoryNames = context.CategoryProductMappings
                                            .Where(mapping => mapping.ProductId == p.Id)
                                            .Select(mapping => mapping.Category.Name)
                                            .ToList(),
                                         CategoryIds = context.CategoryProductMappings
                                            .Where(mapping => mapping.ProductId == p.Id)
                                            .Select(mapping => mapping.CategoryId)
                                            .ToList(),
                                         
                                        

                                         ProductImages = p.ProductImages.Select(i => i.Base64Image).ToList(),
                                         ProductSizes = p.ProductSizes.Select(s => s.Size).ToList()
                                     })
                              .FirstOrDefaultAsync();

                response.Message = ResponseMessage.Success;
                response.Result = product;
                return response;
            }
            catch (Exception ex)
            {

                var result = new GenericBaseResult<GetProductRequestDto>(null);
                result.AddExceptionLog(ex);
                return result;
            }
        }

       
        public async Task<GenericBaseResult<AddProductRequestDto>> AddAsync(AddProductRequestDto addProductRequestDto)
        {
            var response = new GenericBaseResult<AddProductRequestDto>(null);
            try
            {
                var sizes = addProductRequestDto.ProductSizes.FirstOrDefault();
                if (sizes != null)
                {
                    addProductRequestDto.ProductSizes = sizes.Split(",").ToList();
                }

                var product = new Core.Entities.Product
                {
                    Title = addProductRequestDto.Title,
                    Description = addProductRequestDto.Description,
                    UnitPrice = addProductRequestDto.UnitPrice,
                    UnitsInStock = addProductRequestDto.UnitsInStock,
                    ProductCode = addProductRequestDto.ProductCode,
                    //Department = addProductRequestDto.Department, 
                    CreatedBy = "Admin",
                    Created = DateTime.Now,

                };

                if (addProductRequestDto.ImageFiles != null && addProductRequestDto.ImageFiles.Any())
                {
                    var productImages = new List<ProductImages>();
                    foreach (var file in addProductRequestDto.ImageFiles)
                    {
                        using var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var base64Image = Convert.ToBase64String(memoryStream.ToArray());

                        productImages.Add(new ProductImages
                        {
                            Base64Image = base64Image,
                            Name = file.FileName,
                            Product = product,
                            CreatedBy = "Admin",
                            Created = DateTime.Now,
                        });
                    }
                    product.ProductImages = productImages;
                }


                if (addProductRequestDto.ProductSizes != null && addProductRequestDto.ProductSizes.Any())
                {
                    var productSizes = addProductRequestDto.ProductSizes.Select(size => new ProductSize
                    {
                        Size = size,
                        Product = product,
                        CreatedBy = "Admin",
                        Created = DateTime.Now,
                    }).ToList();

                    product.ProductSizes = productSizes;
                }


                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                if (addProductRequestDto.CategoryIds != null && addProductRequestDto.CategoryIds.Any())
                {
                    var categoryProductMappings = addProductRequestDto.CategoryIds.Select(categoryId => new CategoryProductMapping
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id,
                        CreatedBy = "Admin",
                        Created = DateTime.Now,
                    }).ToList();


                    await context.CategoryProductMappings.AddRangeAsync(categoryProductMappings);
                }
                if (addProductRequestDto.DepartmentIds != null && addProductRequestDto.DepartmentIds.Any())
                {
                    var departmentProductMappings = addProductRequestDto.DepartmentIds.Select(departmentId => new DepartmentProductMapping
                    {
                        DepartmentId = departmentId,
                        ProductId = product.Id,
                        CreatedBy = "Admin",
                        Created = DateTime.Now,
                    }).ToList();


                    await context.DepartmentProductMappings.AddRangeAsync(departmentProductMappings);
                    await context.SaveChangesAsync();
                    response.Message = ResponseMessage.RecordSaved;
                    return response;
                }
                
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<AddProductRequestDto>(null);
                result.AddExceptionLog(ex);
                return result;

            }
            return response;

        }

        public async Task<GenericBaseResult<AddProductRequestDto>> UpdateAsync(AddProductRequestDto addProductRequestDto)
        {
            var response = new GenericBaseResult<AddProductRequestDto>(null);
            try
            {
                var sizes = addProductRequestDto.ProductSizes.FirstOrDefault();
                if (sizes != null)
                {
                    addProductRequestDto.ProductSizes = sizes.Split(",").ToList();
                }
                var product = await context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductSizes)
                .FirstOrDefaultAsync(p => p.Id == addProductRequestDto.Id);

                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with Id {addProductRequestDto.Id} not found.");
                }

                product.Title = addProductRequestDto.Title;
                product.Description = addProductRequestDto.Description;
                product.UnitPrice = addProductRequestDto.UnitPrice;
                product.UnitsInStock = addProductRequestDto.UnitsInStock;
                product.ProductCode = addProductRequestDto.ProductCode;
                //product.Department = addProductRequestDto.Department;
                product.LastModifiedBy = "Admin";
                product.LastModified = DateTime.Now;


                if (addProductRequestDto.ImageFiles != null && addProductRequestDto.ImageFiles.Any())
                {

                    product.ProductImages.Clear();


                    var productImages = new List<ProductImages>();
                    foreach (var file in addProductRequestDto.ImageFiles)
                    {
                        using var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var base64Image = Convert.ToBase64String(memoryStream.ToArray());

                        productImages.Add(new ProductImages
                        {
                            Base64Image = base64Image,
                            Name = file.FileName,
                            Product = product,
                            CreatedBy = "Admin",
                            Created = DateTime.Now
                        });
                    }

                    product.ProductImages = productImages;
                }


                if (addProductRequestDto.ProductSizes != null && addProductRequestDto.ProductSizes.Any())
                {
                    // Get existing product sizes for the product
                    var existingProductSizes = product.ProductSizes.ToList();

                    // Find product sizes that are currently used in the Cart table for this product
                    var productSizeIdsInCart = await context.Carts
                        .Where(cart => cart.ProductId == product.Id &&
                                       existingProductSizes.Select(ps => ps.Id).Contains(cart.ProductSizeId))
                        .Select(cart => cart.ProductSizeId)
                        .ToListAsync();

                    // Do not remove conflicting sizes (used in the Cart)
                    var conflictingSizes = existingProductSizes
                        .Where(ps => productSizeIdsInCart.Contains(ps.Id))
                        .ToList();

                    // Find removable sizes (not in use in Cart and not present in new sizes)
                    var removableSizes = existingProductSizes
                        .Where(ps => !productSizeIdsInCart.Contains(ps.Id) &&
                                     !addProductRequestDto.ProductSizes.Contains(ps.Size))
                        .ToList();


                    foreach (var size in removableSizes)
                    {
                        product.ProductSizes.Remove(size);
                    }
                    //if(addProductRequestDto.ProductSizes.Where(i=>i.).Contains(conflictingSizes))

                    // Add new sizes or update existing sizes
                    foreach (var size in addProductRequestDto.ProductSizes)
                    {
                        var existingSize = existingProductSizes.FirstOrDefault(ps => ps.Size == size);

                        if (existingSize == null)
                        {
                            // Add new size if not already present
                            product.ProductSizes.Add(new ProductSize
                            {
                                Size = size,
                                Product = product,
                                CreatedBy = "Admin",
                                Created = DateTime.Now
                            });
                        }
                        else if (productSizeIdsInCart.Contains(existingSize.Id))
                        {
                            // If the size is in the cart, modify its properties if needed (optional, based on requirements)
                            existingSize.LastModifiedBy = "Admin";
                            existingSize.LastModified = DateTime.Now;
                        }
                    }
                }


                if (addProductRequestDto.CategoryIds != null && addProductRequestDto.CategoryIds.Any())
                {
                    var existingCategoryMappings = context.CategoryProductMappings
                        .Where(mapping => mapping.ProductId == product.Id)
                        .ToList();
                    context.CategoryProductMappings.RemoveRange(existingCategoryMappings);

                    var categoryProductMappings = addProductRequestDto.CategoryIds.Select(categoryId => new CategoryProductMapping
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id,
                        CreatedBy = "Admin",
                        Created = DateTime.Now
                    }).ToList();
                    await context.CategoryProductMappings.AddRangeAsync(categoryProductMappings);
                }

                if (addProductRequestDto.DepartmentIds != null && addProductRequestDto.DepartmentIds.Any())
                {
                    var existingDepartmentMappings = context.DepartmentProductMappings
                        .Where(mapping => mapping.ProductId == product.Id)
                        .ToList();
                    context.DepartmentProductMappings.RemoveRange(existingDepartmentMappings);

                    var departmentProductMappings = addProductRequestDto.DepartmentIds.Select(departmentId => new DepartmentProductMapping
                    {
                        DepartmentId = departmentId,
                        ProductId = product.Id,
                        CreatedBy = "Admin",
                        Created = DateTime.Now
                    }).ToList();
                    await context.DepartmentProductMappings.AddRangeAsync(departmentProductMappings);
                }
                await context.SaveChangesAsync();
                response.Message = ResponseMessage.RecordSaved;
                return response;
            }
            catch (Exception ex)
            {
                var result = new GenericBaseResult<AddProductRequestDto>(null);
                result.AddExceptionLog(ex);
                return result;

            }
            return response;



            return new GenericBaseResult<AddProductRequestDto>(null)
            {

            };
        }

        public async Task<GenericBaseResult<DeleteProductDto>> DeleteProductByIdAsync(string productId)
        {
            var response = new GenericBaseResult<DeleteProductDto>(null);
            try
            {
                var product = await context.Products
                    .Where(p => p.Id == productId)
                    .Select(p => new
                    {
                        Product = p,
                        ProductImages = context.ProductImages.Where(img => img.ProductId == productId).ToList(),
                        ProductSizes = context.ProductSizes.Where(size => size.ProductId == productId).ToList(),
                        DepartmentMappings = context.DepartmentProductMappings.Where(dpm => dpm.ProductId == productId).ToList(),
                        CategoryMappings = context.CategoryProductMappings.Where(cpm => cpm.ProductId == productId).ToList()
                    })
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    response.Message = ResponseMessage.NotFound;
                    return response;
                }

                if (product.ProductImages.Any())
                    context.ProductImages.RemoveRange(product.ProductImages);

                if (product.ProductSizes.Any())
                    context.ProductSizes.RemoveRange(product.ProductSizes);

                if (product.DepartmentMappings.Any())
                    context.DepartmentProductMappings.RemoveRange(product.DepartmentMappings);

                if (product.CategoryMappings.Any())
                    context.CategoryProductMappings.RemoveRange(product.CategoryMappings);

                context.Products.Remove(product.Product);

                await context.SaveChangesAsync();

                response.Message = ResponseMessage.ReecordDeleted;
            }
            catch (Exception ex)
            {
                response.AddExceptionLog(ex);
            }

            return response;

        }





    }
}
