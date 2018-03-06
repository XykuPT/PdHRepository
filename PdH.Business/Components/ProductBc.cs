using PdH.Business.Interfaces;
using PdH.Data.Components.Repositories;
using PdH.Entities;
using System;
using System.Collections.Generic;

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
            product.IsActive = false;

            //TODO: fill created on/by and updated on/by with user data

            return _productRepository.Add(product);
        }

        public Product Get(long id)//isto faz sentido ir duas vezes ao metedo?
        {
            var dbProduct = _productRepository.Get(id);
            if(dbProduct == null)
            {
                throw new Exception("Não existe produto com esse ID.");
            }
            return _productRepository.Get(id);
        }

        public Product GetByCode(string code)
        {
            var dbProduct = _productRepository.GetByCode(code);
            if(dbProduct == null)
            {
                throw new Exception("Não existe produto com esse Code.");
            }
            return _productRepository.GetByCode(code);
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

        public Product Edit(Product product)
        {
            var dbProduct = _productRepository.Get(product.Id);
            if(dbProduct == null)
            {
                throw new Exception("O produto não existe");
            }

            dbProduct.Code = product.Code;
            dbProduct.Name = product.Name;
            dbProduct.Material = product.Material;
            dbProduct.Color = product.Color;
            dbProduct.Size = product.Size;
            dbProduct.Stock = product.Stock;
            dbProduct.Price = product.Price;
            dbProduct.Category = product.Category;

            //TODO: fill updated on/by with user data
            return _productRepository.Edit(product);
        }

        public Product ChangeStatus(Product product)
        {
            var dbProduct = _productRepository.Get(product.Id);
            if(dbProduct == null)
            {
                throw new Exception("O produto não existe");
            }
            if(!dbProduct.IsActive == true && dbProduct.Stock <= 0)
            {
                throw new Exception("Para activar o produto este tem de ter stock");
            }

            
            dbProduct.IsActive = !dbProduct.IsActive;

            //TODO: fill updated on/by with user data
            return _productRepository.Edit(dbProduct);

        }

        public Product AddStock(Product product, long stock)
        {
            var dbProduct = _productRepository.Get(product.Id);
            if (dbProduct == null)
            {
                throw new Exception("O produto não existe");
            }

            dbProduct.Stock += stock;
            //TODO: fill updated on/by with user data
            return _productRepository.Edit(dbProduct);
        }

        public Product RemoveStock(long id,long sellQuantity)//TODO: passar a receber ID
        {
            var dbProduct = _productRepository.Get(id);
            if(dbProduct == null)
            {
                throw new Exception("O produto não existe");
            }
            if(dbProduct.IsActive == false)
            {
                throw new Exception("O produto que deseja não está activo.");
            }
            if(dbProduct.Stock == 0 || sellQuantity > dbProduct.Stock)
            {
                throw new Exception("Este produto não tem stock suficiente para venda");
            }

            dbProduct.Stock -= sellQuantity;
            //TODO: fill updated on/by with user data
            return _productRepository.Edit(dbProduct);
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
    }
}
