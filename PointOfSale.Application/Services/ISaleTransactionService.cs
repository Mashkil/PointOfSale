using PointOfSale.Application.Models;
using PointOfSale.DataAccess.Entities;

namespace PointOfSale.Application.Services
{
    public interface ISaleTransactionService
    {
        Task<Guid> Create(SaleTransactionDTO saleTransactionDTO);
        List<SaleTransaction> GetAllByStoreGLN(string GLN);
    }
}
