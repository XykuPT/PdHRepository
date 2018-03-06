using PdH.Business.Interfaces;
using PdH.Data.Components.Repositories;
using PdH.Entities;
using System;

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

        //TODO: GET'S

    }
}
