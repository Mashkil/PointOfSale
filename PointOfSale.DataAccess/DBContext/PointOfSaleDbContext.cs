using Microsoft.EntityFrameworkCore;
using PointOfSale.DataAccess.Entities;

namespace PointOfSale.DataAccess.DBContext
{

    public class PointOfSaleDbContext : DbContext
    {
        public PointOfSaleDbContext(DbContextOptions<PointOfSaleDbContext> options) : base(options)
        {

        }

        public DbSet<SaleTransaction> SaleTransactions { get; set; }
        public DbSet<SaleTransactionPosition> SaleTransactionsPositions { get; set; }
    }
}