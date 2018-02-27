﻿using PdH.Data.Context.Mappings;
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

        public IEnumerable<Product> Search(string name)//falta aqui parametros para um advanced search
        {
            //TODO: this teste
            throw new NotImplementedException();
        }


        //TODO: count para fazer paginação

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
