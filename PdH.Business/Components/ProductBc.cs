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
        private ProductRepository _productRepository;

        public ProductBc()
        {
            _productRepository = new ProductRepository();

        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            var dbProduct = _productRepository.Get(product.Id);
            if (dbProduct == null)
            {
                throw new Exception("O produto que pretende apagar não existe");
            }

            _productRepository.Delete(dbProduct);
        }

        public Product Get(long id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
