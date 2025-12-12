using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImagePath = c.ImagePath,
                    Description = c.Description
                }).ToListAsync(cancellationToken);
        }

        public async Task<GetCategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {

            return await _context.Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    ImagePath = c.ImagePath
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> IsExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name, cancellationToken);
        }

        public async Task<bool> Create(CreateCategoryDto createCategoryDto)
        {

            var entity = new Category()
            {
                Description = createCategoryDto.Description,
                ImagePath = createCategoryDto.ImagePath,
                CreatedAt = DateTime.Now,
                Name = createCategoryDto.Name,

            };
            _context.Categories.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
        {

            return await _context.Categories.Where(c => c.Id == categoryId).ExecuteDeleteAsync(cancellationToken) > 0;
        }

        public async Task<string?> GetImagePath(int categoryId)
        {
            return await _context.Categories.AsNoTracking()
                .Where(u => u.Id == categoryId)
                .Select(u => u.ImagePath)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(GetCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {

            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updateCategoryDto.Id);

                if (category is not null)
                {
                    category.Description = updateCategoryDto.Description;
                    category.Name = updateCategoryDto.Name;
                    category.UptatedAt = DateTime.Now;
                    category.ImagePath = string.IsNullOrEmpty(updateCategoryDto.ImagePath) ? category.ImagePath : updateCategoryDto.ImagePath;

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
