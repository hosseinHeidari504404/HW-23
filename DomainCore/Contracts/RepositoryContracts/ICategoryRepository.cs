using DomainCore.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.RepositoryContracts
{
    public interface ICategoryRepository
    {
        Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<GetCategoryDto?> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Create(CreateCategoryDto createCategoryDto);
        Task<bool> Delete(int categoryId, CancellationToken cancellationToken);
        Task<bool> Update(GetCategoryDto updateCategoryDto, CancellationToken cancellationToken);
        Task<bool> IsExist(string name, CancellationToken cancellationToken);
        Task<string?> GetImagePath(int categoryId);
    }
}
