using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdH.Entities
{
    public class SaleDetails
    {
        //SCALAR PROPERTIES
        public long Id { get; set; }

        public long SalesId { get; set; }

        public decimal Units { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Amount { get; set; }
        //SCALAR PROPERTIES

        //NAVIGATION PROPERTIES
        public virtual Sales Sales { get; set; }
        //NAVIGATION PROPERTIES
    }
}
