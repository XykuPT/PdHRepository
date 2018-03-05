using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdH.Business;
using PdH.Business.Interfaces;
using PdH.Entities;
using System;

namespace PdH.Tests.Business
{
    [TestClass]
    public class SaleDetailsBcTests
    {
        private ISaleDetailsBc _SaleDetailsBc;

        [TestInitialize]
        public void TestInitialize()
        {
            _SaleDetailsBc = new SaleDetailsBc();
        }

        [TestMethod]
        public void SaleDetailsBc_Add()
        {
           






        }
    }
}
