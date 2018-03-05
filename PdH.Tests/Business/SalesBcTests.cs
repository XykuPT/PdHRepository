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

        }
    }
}
