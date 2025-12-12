using DbHandeller.Db_Access;
using DomainCore.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WalletRepository(AppDbContext _context) : IWalletRepository
    {
        public async Task<bool> Update(int userId, decimal newAmount, CancellationToken cancellationToken)
        {
            return await _context.Wallets.Where(w => w.UserId == userId)
                .ExecuteUpdateAsync(w => w.SetProperty
                (wal => wal.Amount, newAmount), cancellationToken) > 0;

        }
    }
}
