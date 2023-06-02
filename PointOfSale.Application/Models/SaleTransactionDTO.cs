namespace PointOfSale.Application.Models
{
    public class SaleTransactionDTO
    {
        public Guid ClientId { get; set; }
        public string GlobalLocationNumber { get; set; }

        public ICollection<SaleTransactionPositionDTO> SaleTransactionPositionsDTO { get; set; }
    }
}