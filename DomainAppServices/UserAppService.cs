using DomainCore.Contracts.AppServicesContracts;
using DomainCore.Contracts.ServicrsContracts;
using DomainCore.Dtos.UserDtos;
using DomainCore.Dtos.Z.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAppServices
{
    public class UserAppService(IUserService userService) : IUserAppService
    {
        public async Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken)
        {
            return await userService.GetUsers(cancellationToken);
        }

        public async Task<GetUserDto> GetUserDetails(int userId, CancellationToken cancellationToken)
        {
            return await userService.GetUserDetails(userId, cancellationToken);
        }

        public async Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken)
        {
            return await userService.GetUserWalletBalance(userId, cancellationToken);
        }

        public async Task<ResultDto<UserLoginDto>> Login(string username, string password, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(username))
            {

                return ResultDto<UserLoginDto>.Failure("Username cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(password))
            {

                return ResultDto<UserLoginDto>.Failure("Password cannot be empty.");
            }

            var result = await userService.Login(username, password, cancellationToken);
            if (result is not null)
            {
                return ResultDto<UserLoginDto>.Success("Login successful.", result);
            }
            return ResultDto<UserLoginDto>.Failure("Invalid username or password!", result);
        }
    }
}
