using DomainCore.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.ServicrsContracts
{
    public interface IUserService
    {
        Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken);
        Task<UserLoginDto> Login(string username, string password, CancellationToken cancellationToken);
        Task<GetUserDto?> GetUserDetails(int userId, CancellationToken cancellationToken);
        Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken);
    }
}
