using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PdH.Data.Components.Repositories
{
    public class SaleDetailsRepository
    {
        public SaleDetails Add(SaleDetails saleDetails)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<SaleDetails>();

            dbSet.Add(saleDetails);
            dbContext.SaveChanges();

            return saleDetails;
        }

        public object Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}
