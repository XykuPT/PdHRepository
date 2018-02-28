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
    public class SalesBc : ISalesBc
    {
        private SalesRepository _salesRepository;

        public SalesBc()
        {
            _salesRepository = new SalesRepository();
        }

        public Sales Add(Sales sales)
        {
            var dbSales = _salesRepository.Get(sales.Id);
            if(dbSales != null)
            {
                throw new Exception("Já existe uma venda com este ID.");
            }
            return _salesRepository.Add(sales);
        }

        public Sales Get(long id)
        {
            var dbSales = _salesRepository.Get(id);
            if(dbSales == null)
            {
                throw new Exception("Não existe venda com esse ID.");
            }
            return _salesRepository.Get(id);
        }

        public IEnumerable<Sales> Search(
            int pageNumber, 
            int pageSize, 
            string productCode = null, 
            long? customerKey = null, 
            DateTime? saleDate = null)
        {
            return _salesRepository.Search(pageNumber, pageSize, productCode, customerKey, saleDate);
        }

        public long Count(string productCode, long? customerKey, DateTime? saleDate)
        {
            return _salesRepository.Count(productCode, customerKey, saleDate);
        }

    }
}
