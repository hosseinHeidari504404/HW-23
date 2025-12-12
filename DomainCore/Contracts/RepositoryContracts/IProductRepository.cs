using DomainCore.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.RepositoryContracts
{
    public interface IProductRepository
    {
        Task<List<GetProductDto>> GetAll(CancellationToken cancellationToken);
        Task<GetProductDto?> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<GetProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellationToken);
        Task<int> GetProductCount(int productId, CancellationToken cancellationToken);
        Task<bool> UpdateCount(int productId, int count, CancellationToken cancellationToken);
        Task<bool> Create(CreateProductDto createProductDto);
        Task<bool> Delete(int productId, CancellationToken cancellationToken);
        Task<UpdateProductDto?> GetUpdatedProduct(int productId, CancellationToken cancellationToken);

        Task<string?> GetImagePath(int productId, CancellationToken cancellationToken);
        Task<bool> Update(UpdateProductDto updateProductDto, CancellationToken cancellationToken);
    }
}
