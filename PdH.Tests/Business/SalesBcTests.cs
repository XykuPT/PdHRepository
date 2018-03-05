using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdH.Business;
using PdH.Business.Interfaces;
using PdH.Entities;
using System;

namespace PdH.Tests.Business
{
    [TestClass]
    public class SalesBcTests
    {
        private ISalesBc _salesBc;

        [TestInitialize]
        public void TestInitialize()
        {
            _salesBc = new SalesBc();
        }

        [TestMethod]
        public void Sales_Add()
        {
            var newSale = new Sales
            {
                TotalAmount = 60,
                TotalUnits = 3,
                CustomerKey = 1

            };
            var saleDetails = new[]
            {
                new SaleDetails{
                    ProductId = 604,
                    ProductAmount = 50,
                    ProductQuantity = 2,
                },
                new SaleDetails
                {
                    ProductId = 605,
                    ProductAmount = 10,
                    ProductQuantity = 1,
                }
            };
            newSale.SaleDetails = saleDetails;
            var salesCreated = _salesBc.Add(newSale);

            Assert.IsTrue(newSale.Id != 0);

            foreach (var item in newSale.SaleDetails)
            {
                Assert.IsTrue(item.SaleId == newSale.Id);
            }
        }
    }
}
