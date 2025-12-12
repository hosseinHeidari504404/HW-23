using DomainCore.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<UserLoginDto> Login(string username, string password, CancellationToken cancellationToken);
        Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken);
        Task<GetUserDto?> GetUserDetails(int userId, CancellationToken cancellationToken);
        Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken);
    }
}
