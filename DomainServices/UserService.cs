using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class UserService(IUserRepository _repo) : IUserService
    {
        public async Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken)
        {
            return await _repo.GetUsers(cancellationToken);
        }

        public async Task<GetUserDto> GetUserDetails(int userId, CancellationToken cancellationToken)
        {
            return await _repo.GetUserDetails(userId, cancellationToken);
        }

        public async Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken)
        {
            return await _repo.GetUserWalletBalance(userId, cancellationToken);
        }

        public async Task<UserLoginDto> Login(string username, string password, CancellationToken cancellationToken)
        {
            return await _repo.Login(username, password, cancellationToken);
        }
    }
}
