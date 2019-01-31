using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.Net.Service;
using SuperSimpleStockMarket.Net.Service.Impl;

namespace SuperSimpleStockMarket.Net
{
    [TestClass]
    public class WhenStockServiceIsRequested
    {
        [TestMethod]
        public void WhenCalculateDividendYieldIsInvokedForTEA()
        {
            IStockService service = new StockService();

            double result = service.CalculateDividendYield("TEA", 123);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void WhenCalculateDividendYieldIsInvokedForGIN()
        {
            IStockService service = new StockService();

            double result = service.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForGIN()
        {
            IStockService service = new StockService();

            double result = service.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForTEA()
        {
            IStockService service = new StockService();

            double result = service.CalculateDividendYield("TEA", 123);
            Assert.IsTrue(result == 0);
        }
    }
}
