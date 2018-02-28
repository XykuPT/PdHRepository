using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PdH.Data.Components.Repositories
{
    /// <summary>
    /// Repository to connect with Database
    /// </summary>
    public class SalesRepository
    {
        /// <summary>
        /// Add new Sale by the user
        /// </summary>
        /// <param name="sales">Dictionary of a Sale containing all attributes of Sale</param>
        /// <returns>Returns new Sale</returns>
        public Sales Add(Sales sales)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            dbSet.Add(sales);
            dbContext.SaveChanges();

            return sales;
        }

        /// <summary>
        /// Search Sale by ID
        /// </summary>
        /// <param name="id">Sale ID</param>
        /// <returns>Returns the Sale with specific ID</returns>
        public Sales Get(long id)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Sales>();

            return dbSet.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Search for all Sales or filtered search
        /// </summary>
        /// <param name="pageNumber">Page number of the site</param>
        /// <param name="pageSize">How many Sales are shown in one page</param>
        /// <param name="productCode">Product Code searching for</param>
        /// <param name="customerKey">CustomerKey searching for</param>
        /// <param name="saleDate">When was the sale created</param>
        /// <returns>Returns all sales searched for</returns>
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

        /// <summary>
        /// Counts how many sales the search received 
        /// </summary>
        /// <param name="productCode">Product Code searching for</param>
        /// <param name="customerKey">CustomerKey searching for</param>
        /// <param name="saleDate">When was the sale created</param>
        /// <returns>Returns the number of Sales of the search</returns>
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
