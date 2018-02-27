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
            var dbContext = new PdHContext();
            var dbSet = dbContext.Set<Product>();

            return dbSet.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> Search(string name)//falta aqui parametros para um advanced search
        {
            //TODO: this
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            var dbContext
        }
    }
}
