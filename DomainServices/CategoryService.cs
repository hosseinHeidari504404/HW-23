using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class CategoryService(ICategoryRepository _repo, IFileService fileService) : ICategoryService
    {
        public async Task<bool> Create(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.ImagePath = fileService.Upload(createCategoryDto.ImageFile, "Category");
            return await _repo.Create(createCategoryDto);
        }

        public async Task<bool> Delete(int categoryId, CancellationToken cancellationToken)
        {
            return await _repo.Delete(categoryId, cancellationToken);
        }

        public async Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<GetCategoryDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task<bool> IsExist(string name, CancellationToken cancellationToken)
        {
            return await _repo.IsExist(name, cancellationToken);
        }

        public async Task<bool> Update(GetCategoryDto updateCategoryDto, CancellationToken cancellationToken)
        {
            if (updateCategoryDto.ImageFile is not null)
            {
                var currentImage = await _repo.GetImagePath(updateCategoryDto.Id);
                if (!string.IsNullOrEmpty(currentImage))
                {
                    fileService.Delete(currentImage);

                }
                updateCategoryDto.ImagePath = fileService.Upload(updateCategoryDto.ImageFile, "Category");
            }
            return await _repo.Update(updateCategoryDto, cancellationToken);
        }
    }
}
