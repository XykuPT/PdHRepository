using PdH.Entities;
using System.Collections.Generic;

namespace PdH.Business.Interfaces
{
    public interface IProductBc
    {
        Product Add(Product product);

        Product Get(long id);

        IEnumerable<Product> Search(string name);

        void Delete(Product product);

    }
}
