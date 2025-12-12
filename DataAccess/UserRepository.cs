using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Dtos.UserDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public async Task<UserLoginDto?> Login(string username, string password, CancellationToken cancellationToken)
        {
            return _context.Users
                .AsNoTracking()
                .Where(u => u.Username == username && u.PasswordHash == password)
                .Select(u => new UserLoginDto
                {
                    UserId = u.Id,
                    UserName = u.Username,
                    IsAdmin = u.IsAdmin
                })
                .FirstOrDefault();
        }
        public async Task<decimal> GetUserWalletBalance(int userId, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Wallet.Amount)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<GetUserDto?> GetUserDetails(int userId, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => new GetUserDto
                {

                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Phone = u.Phone,
                    WalletCount = u.Wallet.Amount,
                    Address = u.Address,
                    Username = u.Username,
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<GetUserDto>> GetUsers(CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(u => u.IsAdmin == false)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    orderCount = u.Orders.Count,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
