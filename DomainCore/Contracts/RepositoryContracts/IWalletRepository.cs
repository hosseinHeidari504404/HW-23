using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.RepositoryContracts
{
    public interface IWalletRepository
    {
        Task<bool> Update(int userId, decimal newAmount, CancellationToken cancellationToken);
    }
}
