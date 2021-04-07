using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blip.Domain
{
    public class Item
    {
        public Item()
        {
            OrderItems = new List<OrderItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ItemID { get; set; }

        [Required]
        [MaxLength(128)]
        public String Description { get; set; }

        public int ReorderQuantity { get; set; }

        public decimal MSRP { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
