using System;
using System.Collections.Generic;
using System.Text;

namespace DomainCore.Contracts.ServicrsContracts
{
    public interface IWalletService
    {
        Task<bool> Update(int userId, decimal newAmount, CancellationToken cancellationToken);
    }
}
