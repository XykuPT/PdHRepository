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
        private ISaleDetailsBc _saleDetailsBc;
        private IProductBc _productBc;

        [TestInitialize]
        public void TestInitialize()
        {
            _salesBc = new SalesBc();
            _saleDetailsBc = new SaleDetailsBc();
            _productBc = new ProductBc();
        }

        [TestMethod]
        public void Sales_Add()
        {
            var newProduct = new Product
            {

                Name = $"SalesAddRandomName{TestUtils.GetRandomGuidAsString(5)}",
                Code = $"RandomCode{TestUtils.GetRandomGuidAsString(5)}",
                Color = $"RandomColor{TestUtils.GetRandomGuidAsString(5)}",
                Size = $"RandomSize{TestUtils.GetRandomGuidAsString(5)}",
                CreatedBy = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                CreatedOn = DateTime.Now,
                Stock =  TestUtils.GetRandomNumeric(1, 10),
                Price = TestUtils.GetRandomDecimal(5,50),
                IsActive = true,

            };
            newProduct.UpdatedBy = newProduct.CreatedBy;
            newProduct.UpdatedOn = newProduct.CreatedOn;
            var product = _productBc.Add(newProduct);

            var newSale = new Sales
            {

                CustomerKey = TestUtils.GetRandomNumeric(1,500)

            };
            var saleDetails = new[]
            {
                new SaleDetails{
                    ProductId = product.Id,
                    ProductAmount = product.Price,
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

        [TestMethod]
        public void Sales_Get()
        {
            var newProduct = new Product
            {

                Name = $"SalesAddRandomName{TestUtils.GetRandomGuidAsString(5)}",
                Code = $"RandomCode{TestUtils.GetRandomGuidAsString(5)}",
                Color = $"RandomColor{TestUtils.GetRandomGuidAsString(5)}",
                Size = $"RandomSize{TestUtils.GetRandomGuidAsString(5)}",
                CreatedBy = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                CreatedOn = DateTime.Now,
                Stock = TestUtils.GetRandomNumeric(1, 10),
                Price = TestUtils.GetRandomDecimal(5, 50),
                IsActive = true,

            };
            newProduct.UpdatedBy = newProduct.CreatedBy;
            newProduct.UpdatedOn = newProduct.CreatedOn;
            var product = _productBc.Add(newProduct);

            var newSale = new Sales
            {

                CustomerKey = TestUtils.GetRandomNumeric(1, 500)

            };
            var saleDetails = new[]
            {
                new SaleDetails{
                    ProductId = product.Id,
                    ProductAmount = product.Price,
                    ProductQuantity = 1,
                }
            };
            newSale.SaleDetails = saleDetails;

            var createdProduct = _salesBc.Add(newSale);
            var searchedProduct = _salesBc.Get(createdProduct.Id);

            Assert.IsTrue(searchedProduct.Id != 0);
            Assert.AreEqual(searchedProduct.TotalAmount, createdProduct.TotalAmount);
            Assert.AreEqual(searchedProduct.TotalQuantity, createdProduct.TotalQuantity);
            Assert.AreEqual(searchedProduct.SaleDate, createdProduct.SaleDate);
            Assert.AreEqual(searchedProduct.SaleDetails, createdProduct.SaleDetails);

        }
    }
}
