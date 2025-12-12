using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Dtos.ProductDtos;
using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        public async Task<List<GetProductDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Category = p.Category.Name,
                    Name = p.Name,
                    Count = p.Count,
                    Price = p.Price,
                    ImagePath = p.ImagePath,
                }).ToListAsync(cancellationToken);
        }

        public async Task<UpdateProductDto?> GetUpdatedProduct(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .Select(p => new UpdateProductDto
                {
                    Id = p.Id,
                    CategoryId = p.Category.Id,
                    Name = p.Name,
                    Count = p.Count,
                    Price = p.Price,
                    ImagePath = p.ImagePath,
                    Description = p.Description,
                }).FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<GetProductDto?> GetDetails(int id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Category = p.Category.Name,
                    Name = p.Name,
                    Count = p.Count,
                    Price = p.Price,
                    Description = p.Description,
                    ImagePath = p.ImagePath,
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<GetProductDto>> GetCategoryProducts(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new GetProductDto
                {
                    Id = p.Id,
                    Category = p.Category.Name,
                    Name = p.Name,
                    Count = p.Count,
                    Price = p.Price,
                    ImagePath = p.ImagePath,
                }).ToListAsync(cancellationToken);

        }

        public async Task<int> GetProductCount(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .Select(p => p.Count)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdateCount(int productId, int count, CancellationToken cancellationToken)
        {

            return await _context.Products.Where(p => p.Id == productId)
                .ExecuteUpdateAsync(p => p.SetProperty(p => p.Count, count), cancellationToken) > 0;
        }

        public async Task<bool> Create(CreateProductDto createProductDto)
        {
            var product = new Product()
            {
                Name = createProductDto.Name,
                CategoryId = createProductDto.CategoryId,
                Price = createProductDto.Price,
                Description = createProductDto.Description,
                ImagePath = createProductDto.ImagePath,
                Count = createProductDto.Count,
                CreatedAt = DateTime.Now,
            };
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(p => p.Id == productId)
                .ExecuteDeleteAsync(cancellationToken) > 0;
        }
        public async Task<string?> GetImagePath(int productId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == productId)
                .Select(p => p.ImagePath)
                .FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<bool> Update(UpdateProductDto updateProductDto, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == updateProductDto.Id, cancellationToken);

                if (product is not null)
                {
                    product.Price = updateProductDto.Price;
                    product.Name = updateProductDto.Name;
                    product.Count = updateProductDto.Count;
                    product.Description = updateProductDto.Description;
                    product.ImagePath = string.IsNullOrEmpty(updateProductDto.ImagePath) ? product.ImagePath : updateProductDto.ImagePath;
                    product.UptatedAt = DateTime.Now;
                    product.CategoryId = updateProductDto.CategoryId;

                    await _context.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
