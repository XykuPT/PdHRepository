﻿using PdH.Entities;
using System.Collections.Generic;

namespace PdH.Business.Interfaces
{
    public interface IProductBc
    {
        Product Add(Product product);

        Product Get(long id);

        Product GetByCode(string code);

        IEnumerable<Product> Search(
            int pageNumber,
            int pageSize,
            string code, 
            string name,
            string material,
            string color,
            string size,
            string category,
            bool? active);

        long Count(
            string code,
            string name,
            string material,
            string color,
            string size,
            string category,
            bool? active);

        Product Edit(Product product);

        Product ChangeStatus(Product product);

        Product AddStock(Product product, long stock);

        Product RemoveStock(Product product, long sellQuantity);

        void Delete(Product product);

    }
}
