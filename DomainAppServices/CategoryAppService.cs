using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAppServices
{
    public class CategoryAppService(ICategoryService categoryService) : ICategoryAppService
    {
        public async Task<ResultDto<bool>> Create(CreateCategoryDto createCategoryDto)
        {
            var result = await categoryService.Create(createCategoryDto);
            if (result)
            {
                return ResultDto<bool>.Success("Category created successfully.", true);
            }
            return ResultDto<bool>.Failure("Failed to create category.", false);
        }

        public async Task<ResultDto<bool>> Delete(int categoryId, CancellationToken cancellationToken)
        {
            var result = await categoryService.Delete(categoryId, cancellationToken);
            if (result)
            {
                return ResultDto<bool>.Success("Category deleted successfully.", true);
            }
            return ResultDto<bool>.Failure("Failed to delete category.", false);
        }

        public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await categoryService.GetAll(cancellationToken);
        }

        public async Task<GetCategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await categoryService.GetById(id, cancellationToken);
        }

        public async Task<ResultDto<bool>> Update(GetCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {
            var result = await categoryService.Update(updateCategoryDto, cancellationToken);
            if (result)
            {
                return ResultDto<bool>.Success("Category updated successfully.", true);
            }
            return ResultDto<bool>.Failure("Failed to update category.", false);
        }
    }
}
