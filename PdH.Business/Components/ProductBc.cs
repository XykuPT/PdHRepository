using PdH.Business.Interfaces;
using PdH.Data.Components.Repositories;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdH.Business
{
    public class ProductBc : IProductBc
    {
        private ProductRepository _productRrepository;

        public ProductBc()
        {
            _productRrepository = new ProductRepository();

        }

        public Product Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(long id)
        {
            return _productRrepository.Get(id);
        }

        public IEnumerable<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
