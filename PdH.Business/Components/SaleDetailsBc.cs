using PdH.Business.Interfaces;
using PdH.Data.Components.Repositories;
using PdH.Entities;
using System;
using System.Collections.Generic;

namespace PdH.Business
{
    public class SaleDetailsBc : ISaleDetailsBc
    {
        private SaleDetailsRepository _saleDetailsRepository;
        

        public SaleDetailsBc()
        {
            _saleDetailsRepository = new SaleDetailsRepository();

        }

        public SaleDetails Add(SaleDetails saleDetails)
        {

            var dbSaleDetails = _saleDetailsRepository.Get(saleDetails.Id);
            if (dbSaleDetails != null)
            {
                throw new Exception("Já existe uma venda com este ID.");
            }
            _saleDetailsRepository.Add(saleDetails);
            

            return saleDetails;
        }

        public SaleDetails Get(long id)
        {
            var dbSaleDetail = _saleDetailsRepository.Get(id);
            if (dbSaleDetail == null)
            {
                throw new Exception("Não existe venda com esse ID.");
            }
            return _saleDetailsRepository.Get(id);
        }

        public IEnumerable<SaleDetails> Search(
            int pageNumber,
            int pageSize, 
            long SaleId, 
            DateTime? saleDate = null)
        {
            return _saleDetailsRepository.Search(pageNumber, pageSize, SaleId, saleDate);
        }

        public long Count(long SaleId, DateTime? saleDate)
        {
            return _saleDetailsRepository.Count(SaleId, saleDate);
        }

    }
}
