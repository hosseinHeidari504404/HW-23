using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class ProductService(IProductRepository _repo, IFileService fileService) : IProductService
    {
        public async Task<bool> Create(CreateProductDto createProductDto)
        {
            createProductDto.ImagePath = fileService.Upload(createProductDto.ImageFile, "Category");
            return await _repo.Create(createProductDto);
        }

        public async Task<bool> Delete(int productId, CancellationToken cancellationToken)
        {
            return await _repo.Delete(productId, cancellationToken);
        }

        public async Task<GetProductDto?> Get(int Id, CancellationToken cancellationToken)
        {
            return await _repo.GetDetails(Id, cancellationToken);
        }

        public async Task<List<GetProductDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<List<GetProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellationToken)
        {
            return await _repo.GetCategoryProducts(categoryId, cancellationToken);
        }

        public async Task<int> GetProductCount(int productId, CancellationToken cancellationToken)
        {
            return await _repo.GetProductCount(productId, cancellationToken);
        }

        public async Task<UpdateProductDto?> GetUpdatedProduct(int productId, CancellationToken cancellationToken)
        {
            return await _repo.GetUpdatedProduct(productId, cancellationToken);
        }

        public async Task<bool> Update(UpdateProductDto updateProductDto, CancellationToken cancellationToken)
        {
            if (updateProductDto.ImageFile is not null)
            {
                var currentImage = await _repo.GetImagePath(updateProductDto.Id, cancellationToken);
                if (!string.IsNullOrEmpty(currentImage))
                {
                    fileService.Delete(currentImage);

                }
                updateProductDto.ImagePath = fileService.Upload(updateProductDto.ImageFile, "Category");
            }
            return await _repo.Update(updateProductDto, cancellationToken);
        }

        public async Task<bool> UpdateCount(int productId, int count, CancellationToken cancellationToken)
        {
            return await _repo.UpdateCount(productId, count, cancellationToken);
        }

    }
}
