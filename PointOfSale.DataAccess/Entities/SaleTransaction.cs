using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DataAccess.Entities
{
    public class SaleTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public Guid ClientId { get; set; }
        [Required]
        public string GlobalLocationNumber { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<SaleTransactionPosition> SaleTransactionPositions { get; set; }
    }
}
