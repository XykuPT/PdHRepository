using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdH.Business;
using PdH.Business.Interfaces;
using PdH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Color = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                    Size = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
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
                Color = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
                Size = $"RandomName{TestUtils.GetRandomGuidAsString(5)}",
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
            Assert.IsNull(deletedProduct);        }


    }
}
