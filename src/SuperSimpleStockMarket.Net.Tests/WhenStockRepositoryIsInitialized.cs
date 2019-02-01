using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStockMarket.Net.Domain;
using SuperSimpleStockMarket.Net.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Net
{
    [TestClass]
    public class WhenStockRepositoryIsInitialized
    {
        private readonly IStockRepository _stockRepository = null;

        public WhenStockRepositoryIsInitialized()
        {
            _stockRepository = new StockRepository();
        }


        [TestMethod]
        public void InitializingStockRepository()
        {
            Assert.IsTrue(_stockRepository.GetAll().Count > 0);
        }

        [TestMethod]
        public void AddingStockToStockRepository()
        {
            _stockRepository.Create(new Domain.Stock
            {
                Id = 99,
                Symbol = "TEST",
                Trades = new List<Trade>()
            });

            Assert.IsTrue(_stockRepository.GetBySymbol("TEST") != null);
        }

        [TestMethod]
        public void GettingStockFromRepositoryBySymbol()
        {
            Assert.IsTrue(_stockRepository.GetBySymbol("TEA") != null);
        }


        [TestMethod]
        public void AddingTradeToStockRepository()
        {
            string symbol = "TEA";
            Stock stock = _stockRepository.GetBySymbol(symbol);

            stock.AddTrade(new Trade
            {
                DateTime = DateTime.Now,
                Price = 1,
                Quantity = 1,
                TradeType = TradeType.BUY,
            });

            _stockRepository.Update(stock);

            Assert.IsTrue(_stockRepository.GetBySymbol(symbol).Trades.Count > 0);
        }
    }
}
