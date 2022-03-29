
using AutoMapper;
using CodeFirst.Core.DTOs.Product.Requests;
using CodeFirst.Core.DTOs.Product.Responses;
using CodeFirst.Core.Interfaces.Repositories;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Exceptions;
using CodeFirst.Domain.Helpers;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Domain.QueryFilters;
using CodeFirst.Domain.QueryFilters.Pagination;
using CodeFirst.Domain.Settings;
using CodeFirst.Domain.Wrappers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly PaginationOptionsSetting _paginationOptions;
        public ProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUriService uriService,
            IOptions<PaginationOptionsSetting> options
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uriService = uriService;
            _paginationOptions = options.Value;
        }
        public PagedResponse<IEnumerable<ProductDtoResponse>> GetProducts(ProductQueryFilter filters, string actionUrl)
        {
            PaginationFilter validFilter = new(filters.PageNumber, filters.PageSize, _paginationOptions);
            IEnumerable<Product> ProductsPagedData = _unitOfWork.ProductRepositoryAsync
                                                            .GetPagedElementsAsync(
                                                                                    validFilter.PageNumber,
                                                                                    validFilter.PageSize,
                                                                                    x => x.Id,
                                                                                    true).Result;

            if (!string.IsNullOrEmpty(filters.Name))
            {
                ProductsPagedData = ProductsPagedData.Where(x => x.Name == filters.Name);
            }

            if (!string.IsNullOrEmpty(filters.Category))
            {
                ProductsPagedData = ProductsPagedData.Where(x => x.Category == filters.Category);
            }
            var total = _unitOfWork.ProductRepositoryAsync.GetCountAsync().Result;

            var ProductMap = _mapper.Map<IEnumerable<ProductDtoResponse>>(ProductsPagedData);

            PagedResponse<IEnumerable<ProductDtoResponse>> response = PaginationHelper.PadageCreateResponse<ProductDtoResponse, Product>(
                                                                    ProductsPagedData.ToList(),
                                                                    validFilter,
                                                                    _paginationOptions,
                                                                    total,
                                                                    _uriService,
                                                                    actionUrl,
                                                                    _mapper
                                                               );
            return response;
        }
        public async Task<Response<ProductDtoResponse>> GetProductAsync(long id)
        {
            Product ProductBuscado = await _unitOfWork.ProductRepositoryAsync.GetByIdAsync(id).ConfigureAwait(false);
            if (ProductBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }
            ProductDtoResponse ProductMap = _mapper.Map<ProductDtoResponse>(ProductBuscado);
            return new Response<ProductDtoResponse>(ProductMap) { Message = "La información solicitada ha sido exitosa." };
        }
        public async Task<Response<ProductDtoResponse>> AddProductAsync(ProductAddDtoRequest Product)
        {
            Product ProductMap = _mapper.Map<Product>(Product);
            await _unitOfWork.ProductRepositoryAsync.AddAsync(ProductMap).ConfigureAwait(false);
            await _unitOfWork.CommitAsync();
            ProductDtoResponse ProductCreado = _mapper.Map<ProductDtoResponse>(ProductMap);
            return new Response<ProductDtoResponse>(ProductCreado) { Message = $"El Product {ProductCreado.Name} ha sido creado." };
        }
        public async Task<Response<ProductDtoResponse>> UpdateProductAsync(long id, ProductAddDtoRequest Product)
        {
            Product ProductBuscado = await _unitOfWork.ProductRepositoryAsync
                                        .GetFirstAsync(x => x.Id.Equals(id))
                                        .ConfigureAwait(false);
            if (ProductBuscado == null) { throw new CoreException("La información solicitada no exitosa."); }

            ProductBuscado.Name = Product.Name;
            ProductBuscado.Description = Product.Description;
            ProductBuscado.Category = Product.Category;
            ProductBuscado.Images = Encoding.ASCII.GetBytes(Product.Images); ;

            await _unitOfWork.ProductRepositoryAsync.UpdateAsync(ProductBuscado);
            await _unitOfWork.CommitAsync();
            ProductDtoResponse ProductActualizado = _mapper.Map<ProductDtoResponse>(ProductBuscado);

            return new Response<ProductDtoResponse>(ProductActualizado) { Message = $"El Product {ProductActualizado.Name} ha sido actualizada." };
        }
        public async Task<Response<bool>> DeleteProductAsync(long id)
        {
            if (id <= 0) { throw new CoreException($"El valor del identificador id debe ser superior a cero(0)."); }
            bool ProductEliminado = await _unitOfWork.ProductRepositoryAsync.DeleteAsync(id).ConfigureAwait(false);
            if (!ProductEliminado) { throw new CoreException("El registro no ha sido Eliminado."); }
            await _unitOfWork.CommitAsync();
            return new Response<bool>(ProductEliminado) { Message = $"El registro solicitado ha sido eliminado." };
        }

    }
}
