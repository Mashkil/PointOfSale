using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Models;
using PointOfSale.DataAccess.DBContext;
using PointOfSale.DataAccess.Entities;
using PointOfSale.Infrastructure.Integrations;

namespace PointOfSale.Application.Services
{
    public class SaleTransactionService : ISaleTransactionService
    {
        private readonly PointOfSaleDbContext _db;
        private readonly IClientsServiceCommunicator clientsServiceCommunicator;

        public SaleTransactionService(PointOfSaleDbContext db, IClientsServiceCommunicator clientsServiceCommunicator)
        {
            _db = db;
            this.clientsServiceCommunicator = clientsServiceCommunicator;
        }
        
        public async Task<Guid> Create(SaleTransactionDTO saleTransactionDTO)
        {
            if (!await clientsServiceCommunicator.IsExisting(saleTransactionDTO.ClientId)) {
                throw new NotFoundException($"The client with {saleTransactionDTO.ClientId} not found");
            }

            List<SaleTransactionPosition> transactionPositionsList = new List<SaleTransactionPosition>();


            foreach (var item in saleTransactionDTO.SaleTransactionPositionsDTO)
            {
                var createTransactionPosition = new SaleTransactionPosition
                {
                    Quantity = item.Quantity,
                    ProductPrice = item.ProductPrice,
                    ProductGTIN = item.ProductGTIN
                };
                await _db.SaleTransactionsPositions.AddAsync(createTransactionPosition);
                transactionPositionsList.Add(createTransactionPosition);
            }

            var createTransaction = new SaleTransaction
            {
                ClientId = saleTransactionDTO.ClientId,
                GlobalLocationNumber = saleTransactionDTO.GlobalLocationNumber,
                Price = saleTransactionDTO.SaleTransactionPositionsDTO.Sum(position => position.Quantity * position.ProductPrice),
                SaleTransactionPositions = transactionPositionsList
            };


            await _db.SaleTransactions.AddAsync(createTransaction);
            await _db.SaveChangesAsync();
            return createTransaction.Id;
        }

        public List<SaleTransaction> GetAllByStoreGLN(string GLN)
        {
            var saleTransactions = _db.SaleTransactions.Where(p => p.GlobalLocationNumber == GLN).Include(p => p.SaleTransactionPositions).ToList();
            return saleTransactions;
        }
    }
}