using PdH.Business.Interfaces;
using PdH.Data.Components.Repositories;
using PdH.Entities;
using System;
using System.Collections.Generic;

namespace PdH.Business
{
    public class SalesBc : ISalesBc
    {
        private SalesRepository _salesRepository;
        private SaleDetailsBc _saleDetailsBc;
        private ProductBc _productBc;
        

        public SalesBc()
        {
            _salesRepository = new SalesRepository();
            _saleDetailsBc = new SaleDetailsBc();
            _productBc = new ProductBc();
        }

        public Sales Add(Sales sales)
        {

            sales.SaleDate = DateTime.Now;

            foreach (var detail in sales.SaleDetails)
            {
                detail.SaleDate = sales.SaleDate;
                //detail.Product = _productBc.Get(detail.ProductId);
                _productBc.RemoveStock(detail.ProductId, detail.ProductQuantity);

            }

            _salesRepository.Add(sales);

            var saleCreated = _salesRepository.Get(sales.Id);

            return saleCreated;
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
            long? customerKey = null, 
            DateTime? saleDate = null)
        {
            return _salesRepository.Search(pageNumber, pageSize, customerKey, saleDate);
        }

        public long Count(long? customerKey, DateTime? saleDate)
        {
            return _salesRepository.Count(customerKey, saleDate);
        }
    }
}
