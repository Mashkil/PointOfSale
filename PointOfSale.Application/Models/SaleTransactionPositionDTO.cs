namespace PointOfSale.Application.Models
{
    public class SaleTransactionPositionDTO
    {
        public decimal Quantity { get; set; }
        public string ProductGTIN { get; set; }
        public decimal ProductPrice { get; set; }
    }
}