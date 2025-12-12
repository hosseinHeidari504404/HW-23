using DomainCore.Dtos.CategoryDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.AppServicesContracts
{
    public interface ICategoryAppService
    {
        Task<List<GetCategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<GetCategoryDto?> GetById(int id, CancellationToken cancellationToken);
        Task<ResultDto<bool>> Create(CreateCategoryDto createCategoryDto);
        Task<ResultDto<bool>> Delete(int categoryId, CancellationToken cancellationToken);
        Task<ResultDto<bool>> Update(GetCategoryDto updateCategoryDto, CancellationToken cancellationToken);
    }
}
