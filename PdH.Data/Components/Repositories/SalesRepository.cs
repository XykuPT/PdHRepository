using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
