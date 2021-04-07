using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blip.Domain
{

    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OrderID { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
