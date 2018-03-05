using PdH.Entities;
using System.Collections.Generic;
using System.Linq;
using PdH.Data.Context.Mappings;
using System.Data.Entity;

namespace PdH.Data.Components.Repositories
{
    /// <summary>
    /// Repository to connect with Database
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// To add new Products to the Database by the Shop Admin
        /// </summary>
        /// <param name="product">Dictionary of a Product containing all attributes of Product</param>
        /// <returns>Product inserted into DB</returns>
        public Product Add(Product product)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            dbSet.Add(product);
            dbContext.SaveChanges();

            return product;
        }
        
        /// <summary>
        /// Search Database for Product with certain ID.
        /// </summary>
        /// <param name="id">ID of one Product</param>
        /// <returns>Returns the Product with that ID.</returns>
        public Product Get(long id)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.FirstOrDefault(p => p.Id == id);
        }
        /// <summary>
        /// Search Database for Product with certain Code.
        /// </summary>
        /// <param name="code">Code of one Product</param>
        /// <returns>Returns the Product with that Code.</returns>
        public Product GetByCode(string code)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.FirstOrDefault(p => p.Code == code);
        }

        /// <summary>
        /// Returns all Products or Filtered search.
        /// </summary>
        /// <param name="pageNumber">Page number of the site</param>
        /// <param name="pageSize">How many products are shown by page</param>
        /// <param name="code">Product Code for filtered search</param>
        /// <param name="name">Product Name for filtered search</param>
        /// <param name="material">Product Material for filtered search</param>
        /// <param name="color">Product Color for filtered search</param>
        /// <param name="size">Product Size for filtered search</param>
        /// <param name="category">Product Category for filtered search</param>
        /// <param name="active">Product Active for filtered search</param>
        /// <returns>Returns all Products of the Search</returns>
        public IEnumerable<Product> Search(
            int pageNumber,
            int pageSize,
            string code = null,
            string name = null,
            string material = null,
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
                    && (material == null || p.Material.Contains(material))
                    && (color == null || p.Color.Contains(color))
                    && (size == null || p.Size.Contains(size))
                    && (category == null || p.Category.Contains(category))
                    && (!active.HasValue || p.IsActive == active))
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        /// <summary>
        /// Count number of Products of the Search for pagination
        /// </summary>
        /// <param name="code">Product Code for filtered search</param>
        /// <param name="name">Product Name for filtered search</param>
        /// <param name="material">Product Material for filtered search</param>
        /// <param name="color">Product Color for filtered search</param>
        /// <param name="size">Product Size for filtered search</param>
        /// <param name="category">Product Category for filtered search</param>
        /// <param name="active">Product Active for filtered search</param>
        /// <returns>Returns the number of Products of the search</returns>
        public long Count(
            string code = null,
            string name = null,
            string material = null,
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
                    && (material == null || p.Material.Contains(material))
                    && (color == null || p.Color.Contains(color))
                    && (size == null || p.Size.Contains(size))
                    && (category == null || p.Category.Contains(category))
                    && (!active.HasValue || p.IsActive == active));
        }

        public Product Edit(Product product)
        {
            var dbContext = new PdHContext();
            
            dbContext.Entry(product).State = EntityState.Modified;
            dbContext.SaveChanges();

            return product;

        }


        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product">Dictionary of a Product containing all attributes of Product</param>
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
