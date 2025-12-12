using DomainCore.Dtos.ProductDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.AppServicesContracts
{
    public interface IProductAppService
    {
        Task<GetProductDto?> Get(int Id, CancellationToken cancellationToken);
        Task<List<GetProductDto>> GetAll(CancellationToken cancellationToken);
        Task<List<GetProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellationToken);
        Task<int> GetProductCount(int productId, CancellationToken cancellationToken);
        Task<ResultDto<bool>> Create(CreateProductDto createProductDto);
        Task<ResultDto<bool>> Delete(int productId, CancellationToken cancellationToken);
        Task<UpdateProductDto?> GetUpdatedProduct(int productId, CancellationToken cancellationToken);
        Task<ResultDto<bool>> Update(UpdateProductDto updateProductDto, CancellationToken cancellationToken);

    }
}
