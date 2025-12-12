using DomainCore.Contracts.RepositoryContracts;
using DomainCore.Contracts.ServicrsContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainServices
{
    public class WalletService(IWalletRepository _repo) : IWalletService
    {
        public async Task<bool> Update(int userId, decimal newAmount, CancellationToken cancellationToken)
        {
            return await _repo.Update(userId, newAmount, cancellationToken);
        }
    }
}
