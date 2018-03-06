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
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<SaleDetails>();

            return dbSet.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<SaleDetails> Search(
           int pageNumber,
           int pageSize,
           long SaleId,
           DateTime? saleDate = null)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<SaleDetails>();

            return dbSet.Include(p => p.Product).Include(s => s.Sales)
                .Where(sd =>
                (sd.SaleId == SaleId) &&
                (!saleDate.HasValue || DbFunctions.TruncateTime(sd.SaleDate) == DbFunctions.TruncateTime(saleDate)))
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public long Count(long SaleId, DateTime? saleDate)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<SaleDetails>();

            return dbSet.LongCount(sd =>
                (sd.SaleId == SaleId) &&
                (!saleDate.HasValue || DbFunctions.TruncateTime(sd.SaleDate) == DbFunctions.TruncateTime(saleDate)));
        }
    }
}
