using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PdH.Data.Components.Repositories
{
    public class SalesRepository
    {
        public Sales Add(Sales sales)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            dbSet.Add(sales);
            dbContext.SaveChanges();

            return sales;
        }

        public Sales Get(long id)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            return dbSet.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sales> Search(
            int pageNumber,
            int pageSize,
            string productCode = null,
            long? costumerKey = null,
            DateTime? saleDate = null)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            return dbSet.Include(p => p.Product)
                .Where()
        }
    }
}
