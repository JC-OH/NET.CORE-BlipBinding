using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blip.Domain
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(3)]
        public string CountryIso3 { get; set; }

        [MaxLength(3)]
        public string RegionCode { get; set; }

        public virtual Country Country { get; set; }

        public virtual Region Region { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
