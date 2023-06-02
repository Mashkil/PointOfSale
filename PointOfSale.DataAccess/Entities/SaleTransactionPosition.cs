using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DataAccess.Entities
{
    public class SaleTransactionPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public string ProductGTIN { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        
        [ForeignKey("SaleTransaction")]
        public Guid SaleTransactionId { get; set; }       
        
        public virtual SaleTransaction SaleTransaction { get; set; }
    }
}