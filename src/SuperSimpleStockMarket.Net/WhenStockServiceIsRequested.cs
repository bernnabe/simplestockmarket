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

            var result = service.CalculateDividendYield("TEA", 123);
            Assert.AreEqual(result.Result, 0);
        }

        [TestMethod]
        public void WhenCalculateDividendYieldIsInvokedForGIN()
        {
            IStockService service = new StockService();

            var result = service.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForGIN()
        {
            IStockService service = new StockService();

            var result = service.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForTEA()
        {
            IStockService service = new StockService();

            var result = service.CalculateDividendYield("TEA", 123);
            Assert.IsTrue(result.Result == 0);
        }

        [TestMethod]
        public void CalculateVolumeWeightedPrice(string symbol)
        {
            IStockService service = new StockService();

            var result = service.CalculateVolumeWeightedPrice("TEA");
            Assert.IsTrue(result.Result > 0);
        }
    }
}
