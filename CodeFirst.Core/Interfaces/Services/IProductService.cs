using CodeFirst.Core.DTOs.Product.Requests;
using CodeFirst.Core.DTOs.Product.Responses;
using CodeFirst.Domain.QueryFilters;
using CodeFirst.Domain.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IProductService
    {
        PagedResponse<IEnumerable<ProductDtoResponse>> GetProducts(ProductQueryFilter filters, string actionUrl);

        Task<Response<ProductDtoResponse>> GetProductAsync(long id);

        Task<Response<ProductDtoResponse>> AddProductAsync(ProductAddDtoRequest Product);

        Task<Response<ProductDtoResponse>> UpdateProductAsync(long id, ProductAddDtoRequest Product);

        Task<Response<bool>> DeleteProductAsync(long id);
    }
}
