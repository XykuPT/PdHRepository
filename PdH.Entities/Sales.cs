using System;
using System.Collections.Generic;

namespace PdH.Entities
{
    public class Sales
    {
        //SCALAR PROPERTIES
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long SaleId { get; set; }

        public long CustomerKey { get; set; }

        public virtual DateTime SaleDate { get; set; }

        //SCALAR PROPERTIES



        //NAVIGATION PROPERTIES
        public virtual Product Product { get; set; }

        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
        //NAVIGATION PROPERTIES
    }
}
