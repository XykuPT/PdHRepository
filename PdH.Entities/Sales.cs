using System;
using System.Collections.Generic;

namespace PdH.Entities
{
    public class Sales
    {
        //SCALAR PROPERTIES
        public long Id { get; set; }

        public decimal TotalAmount { get; set; }

        public long TotalUnits { get; set; }

        public long CustomerKey { get; set; }

        public virtual DateTime SaleDate { get; set; }

        //SCALAR PROPERTIES

        //NAVIGATION PROPERTIES

        //public virtual SaleDetails SaleDetails { get; set; }
        public virtual ICollection<SaleDetails> SaleDetails { get; set; }

        //NAVIGATION PROPERTIES
    }
}
