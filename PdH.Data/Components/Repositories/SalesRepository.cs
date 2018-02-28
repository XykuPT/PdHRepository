using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            long? customerKey = null,
            DateTime? saleDate = null)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            return dbSet.Include(p => p.Product)
                .Where(s =>
                (productCode == null || s.Product.Code.Contains(productCode)) &&
                (customerKey == null || s.CustomerKey == customerKey) && 
                (!saleDate.HasValue || DbFunctions.TruncateTime(s.SaleDate) == DbFunctions.TruncateTime(saleDate)))
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public long Count(string productCode, long? customerKey, DateTime? saleDate)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            return dbSet.LongCount(s =>
                (productCode == null || s.Product.Code.Contains(productCode)) &&
                (customerKey == null || s.CustomerKey == customerKey) &&
                (!saleDate.HasValue || DbFunctions.TruncateTime(s.SaleDate) == DbFunctions.TruncateTime(saleDate)));
        }
    }
}
