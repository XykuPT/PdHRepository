using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdH.Business;
using PdH.Business.Interfaces;
using PdH.Entities;
using System;

namespace PdH.Tests
{
    [TestClass]
    public class ProductsBcTests
    {

        private IProductBc _productBc;

        [TestInitialize]
        public void TestInitialize()
        {
            _productBc = new ProductBc();
        }

        [TestMethod]
        public void ProductBc_Add()
        {
            for (int i = 0; i < 200; i++)
            {
                var newProduct = new Product
                {
                   
                    Name = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                    Code = $"RandomCode{TestUtils.GetRandomGuidAsString(5)}",
                    Color = $"RandomColor{TestUtils.GetRandomGuidAsString(5)}",
                    Size = $"RandomSize{TestUtils.GetRandomGuidAsString(5)}",
                    CreatedBy = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                    CreatedOn = DateTime.Now,

                };
                newProduct.UpdatedBy = newProduct.CreatedBy;
                newProduct.UpdatedOn = newProduct.CreatedOn;

                var createdProduct = _productBc.Add(newProduct);

                Assert.IsTrue(createdProduct.Id != 0);
                Assert.AreEqual(createdProduct.Name, newProduct.Name);
                Assert.AreEqual(createdProduct.Color, newProduct.Color);
                Assert.AreEqual(createdProduct.Size, newProduct.Size);
            }

        }

        [TestMethod]
        public void ProductBc_Get()
        {
            var newProduct = new Product
            {
                Id = TestUtils.GetRandomNumeric(9999),
                Name = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                Code = $"RandomCode{TestUtils.GetRandomGuidAsString(5)}",
                Color = $"RandomColor{TestUtils.GetRandomGuidAsString(5)}",
                Size = $"RandomSize{TestUtils.GetRandomGuidAsString(5)}",
                CreatedBy = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                CreatedOn = DateTime.Now,

            };
            newProduct.UpdatedBy = newProduct.CreatedBy;
            newProduct.UpdatedOn = newProduct.CreatedOn;

            var createdProduct = _productBc.Add(newProduct);
            var searchedProduct = _productBc.Get(createdProduct.Id);

            Assert.IsTrue(searchedProduct.Id != 0);
            Assert.AreEqual(searchedProduct.Name, createdProduct.Name);
            Assert.AreEqual(searchedProduct.Color, createdProduct.Color);
            Assert.AreEqual(searchedProduct.Size, createdProduct.Size);

        }

        //TODO: not implemented
        //[TestMethod]
        //public void ProductBc1_Search()
        //{
        //    var searchedProduct = _productBc.AdvSearch(1, int.MaxValue, "cenas", null, null, null);

        //    Assert.IsTrue(searchedProduct.Count() == 1);

        //}

        [TestMethod]
        public void ProductBc_Delete()
        {
            var newProduct = new Product
            {
                Name = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                Color = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                Size = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                CreatedBy = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                CreatedOn = DateTime.Now,

            };
            newProduct.UpdatedBy = newProduct.CreatedBy;
            newProduct.UpdatedOn = newProduct.CreatedOn;

            var createdProduct = _productBc.Add(newProduct);        

            _productBc.Delete(newProduct);

            var deletedProduct = _productBc.Get(createdProduct.Id);

            Assert.IsTrue(createdProduct.Id != 0);
            Assert.IsNull(deletedProduct);
        }

        [TestMethod]
        public void ProductBc_ChangeStatus()
        {
            var productHasStock = _productBc.Get(604);
            var productNoStock = _productBc.Get(605);

            _productBc.ChangeStatus(productHasStock.Id);
            Assert.IsTrue(productHasStock.IsActive == true);

            try
            {
                _productBc.ChangeStatus(productNoStock.Id);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void ProductBc_AddStock()
        {
            var productHasStock = _productBc.Get(604);
            var stockToAdd = 5;

            var productAfter = _productBc.AddStock(productHasStock.Id, stockToAdd);

            Assert.IsTrue(productAfter.Stock == (productHasStock.Stock + stockToAdd));
        }

        [TestMethod]
        public void ProductBc_RemoveStock()
        {
            var productHasStock = _productBc.Get(604);
            var productNoStock = _productBc.Get(605);
            var sellHasStock = 2;
            var sellNoStock = 1;
            var sellOverStock = 50;

            var modifiedProd = _productBc.RemoveStock(productHasStock.Id, sellHasStock);
            Assert.IsTrue(modifiedProd.Stock == (productHasStock.Stock - sellHasStock));

            try
            {
                _productBc.RemoveStock(productNoStock.Id, sellNoStock);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }

            try
            {
                _productBc.RemoveStock(productHasStock.Id, sellOverStock);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }

        }
    }

}
