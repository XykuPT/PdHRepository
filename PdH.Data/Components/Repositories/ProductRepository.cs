using PdH.Data.Context.Mappings;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdH.Data.Components.Repositories
{
    public class ProductRepository
    {
        public Product Add(Product product)
        {
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.Add(product);
        }
        
        public Product Get(long id)
        {
            //TODO: this
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string name)
        {
            //TODO: this
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            //TODO: this
            throw new NotImplementedException();
        }
    }
}
