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
            var dbProduct = _productRepository.GetByCode(product.Code);
            if(dbProduct != null)
            {
                throw new Exception("Já existe um Produto com esse Código.");
            }
            else
            {
                return _productRepository.Add(product);
            }
        }

        public Product Get(long id)
        {
            var dbProduct = _productRepository.Get(id);
            if(dbProduct == null)
            {
                throw new Exception("Não existe produto com esse ID.");
            }
            else
            {
                return _productRepository.Get(id);
            }
            
        }

        public Product GetByCode(string code)
        {
            var dbProduct = _productRepository.GetByCode(code);
            if(dbProduct == null)
            {
                throw new Exception("Não existe produto com esse Code.");
            }
            else
            {
            return _productRepository.GetByCode(code);
            }

        }

        public IEnumerable<Product> Search(
            int pageNumber, 
            int pageSize, 
            string code, 
            string name,
            string material,
            string color, 
            string size, 
            string category, 
            bool? active)
        {
            return _productRepository.Search(pageNumber, pageSize, code, name, material, color, size, category, active);
        }

        public long Count(
            string code, 
            string name,
            string material,
            string color, 
            string size, 
            string category, 
            bool? active)
        {
            return _productRepository.Count(code, name, material, color, size, category, active);
        }


        public void Delete(Product product)
        {
            var dbProduct = _productRepository.Get(product.Id);
            if (dbProduct == null)
            {
                throw new Exception("O produto que pretende apagar não existe");
            }
            else
            {
            _productRepository.Delete(dbProduct);
            }

        }
    }
}
