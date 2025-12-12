using DomainCore.Dtos.UserDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.AppServicesContracts
{
    public interface IUserAppService
    {
        Task<ResultDto<UserLoginDto>> Login(string username, string password, CancellationToken cancellationToken);
        Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken);
        Task<GetUserDto?> GetUserDetails(int userId, CancellationToken cancellationToken);
        Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken);
    }
}
