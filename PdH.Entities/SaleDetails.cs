using System;
using System.Collections.Generic;

namespace PdH.Entities
{
    public class SaleDetails
    {
        //SCALAR PROPERTIES
        public long Id { get; set; }
        
        public long ProductId { get; set; }

        public long SaleId { get; set; }

        public long ProductQuantity { get; set; }

        public decimal ProductAmount { get; set; }

        public virtual DateTime SaleDate { get; set; }
        //SCALAR PROPERTIES

        //NAVIGATION PROPERTIES

        public virtual Product Product { get; set; }
        //public virtual ICollection<Product> Product { get; set; }

        public virtual Sales Sales { get; set; }
        //public virtual ICollection<Sales> Sales { get; set; }
        //NAVIGATION PROPERTIES
    }
}
