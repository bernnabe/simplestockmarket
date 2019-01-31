using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.Net.Service;
using SuperSimpleStockMarket.Net.Service;

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
            Assert.AreEqual(result.Result, 0);
        }

        [TestMethod]
        public void CalculateVolumeWeightedPrice()
        {
            IStockService service = new StockService();

            var result = service.CalculateVolumeWeightedPrice("TEA");
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public void AddTradeToStock()
        {
            IStockService service = new StockService();

            var result = service.AddTrade("TEA", Domain.TradeType.BUY, 12.0, 1);
            
            Assert.IsTrue(result.Succeded);
        }

        [TestMethod]
        public void AddTradeToStockWithInvalidPrice()
        {
            IStockService service = new StockService();

            var result = service.AddTrade("TEA", Domain.TradeType.BUY, 0, 1);

            Assert.AreEqual(result.Errors.Count, 1);
            Assert.IsFalse(result.Succeded);
        }
    }
}
