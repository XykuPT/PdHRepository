using PdH.Entities;
using System.Collections.Generic;
using System.Linq;
using PdH.Data.Context.Mappings;

namespace PdH.Data.Components.Repositories
{
    public class ProductRepository
    {
        public Product Add(Product product)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            dbSet.Add(product);
            dbContext.SaveChanges();

            return product;
        }
        
        public Product Get(long id)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.FirstOrDefault(p => p.Id == id);
        }




        public Product GetByCode(string code)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.FirstOrDefault(p => p.Code == code);
        }

        public IEnumerable<Product> Search(
            int pageNumber,
            int pageSize,
            string code = null,
            string name = null,
            string color = null,
            string size = null,
            string category = null,
            bool? active = null)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.Where(p =>
                    (code == null || p.Code.Contains(code))
                    && (name == null || p.Name.Contains(name))
                    && (color == null || p.Color.Contains(color))
                    && (size == null || p.Size.Contains(size))
                    && (category == null || p.Category.Contains(category))
                    && (!active.HasValue || p.IsActive == active))
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public long Count(
            string code = null,
            string name = null,
            string color = null,
            string size = null,
            string category = null,
            bool? active = null)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.LongCount(p =>
                  (code == null || p.Code.Contains(code))
                    && (name == null || p.Name.Contains(name))
                    && (color == null || p.Color.Contains(color))
                    && (size == null || p.Size.Contains(size))
                    && (category == null || p.Category.Contains(category))
                    && (!active.HasValue || p.IsActive == active));
        }

        public void Delete(Product product)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            dbSet.Attach(product);
            dbSet.Remove(product);

            dbContext.SaveChanges();
        }
    }
}
