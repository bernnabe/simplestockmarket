using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.Net.Repository.Repositories;
using SuperSimpleStockMarket.Net.Repository.Repositories.Contracts;
using SuperSimpleStockMarket.Net.Service;
using SuperSimpleStockMarket.Net.Service.Contracts;

namespace SuperSimpleStockMarket.Net
{
    [TestClass]
    public class WhenStockServiceIsRequested
    {
        private readonly IStockRepository _stockRepository = null;
        private readonly ITradeRepository _tradeRepository = null;

        private readonly IStockService _stockService = null;
        public WhenStockServiceIsRequested()
        {
            _stockRepository = new StockRepository();
            _tradeRepository = new TradeRepository();

            _stockService = new StockService(_stockRepository, _tradeRepository);
        }

        [TestMethod]
        public void WhenCalculateDividendYieldIsInvokedForTEA()
        {
            var result = _stockService.CalculateDividendYield("TEA", 123);
            Assert.AreEqual(result.Result, 0);
        }

        [TestMethod]
        public void WhenCalculateDividendYieldIsInvokedForGIN()
        {
            var result = _stockService.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForGIN()
        {
            var result = _stockService.CalculateDividendYield("GIN", 123);
            Assert.IsTrue(result.Result > 0);
        }

        [TestMethod]
        public void WhenCalculatePERatioIsInvokedForTEA()
        {
            var result = _stockService.CalculateDividendYield("TEA", 123);
            Assert.AreEqual(result.Result, 0);
        }

        [TestMethod]
        public void CalculateVolumeWeightedPrice()
        {
            var result = _stockService.CalculateVolumeWeightedPrice("TEA");

            //The repo is empty
            Assert.IsFalse(result.Succeded);
        }

        [TestMethod]
        public void AddTradeToStock()
        {
            var result = _stockService.AddTrade("TEA", Domain.TradeType.BUY, 12.0, 1);

            Assert.IsTrue(result.Succeded);
        }

        [TestMethod]
        public void AddTradeToStockWithInvalidPrice()
        {
            var result = _stockService.AddTrade("TEA", Domain.TradeType.BUY, 0, 1);

            Assert.AreEqual(result.Errors.Count, 1);
            Assert.IsFalse(result.Succeded);
        }
    }
}
