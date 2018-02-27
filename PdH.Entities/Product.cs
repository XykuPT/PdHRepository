using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdH.Entities
{
    public class Product
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }   

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public bool? IsActive { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

        public virtual string UpdatedBy { get; set; }
    }
}
