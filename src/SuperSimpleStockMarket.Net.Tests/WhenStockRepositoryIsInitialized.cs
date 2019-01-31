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
        [TestMethod]
        public void InitializingStockRepository()
        {
            StockRepository repository = new StockRepository();

            Assert.IsTrue(repository.GetAll().Count > 0);
        }

        [TestMethod]
        public void AddingStockToStockRepository()
        {
            StockRepository repository = new StockRepository();

            repository.Create(new Domain.Stock
            {
                Id = 99,
                Symbol = "TEST",
                Trades = new List<Trade>()
            });

            Assert.IsTrue(repository.GetBySymbol("TEST") != null);
        }

        [TestMethod]
        public void GettingStockFromRepositoryBySymbol()
        {
            StockRepository repository = new StockRepository();

            Assert.IsTrue(repository.GetBySymbol("TEA") != null);
        }


        [TestMethod]
        public void AddingTradeToStockRepository()
        {
            string symbol = "TEA";
            StockRepository repository = new StockRepository();
            Stock stock = repository.GetBySymbol(symbol);

            stock.AddTrade(new Trade
            {
                DateTime = DateTime.Now,
                Price = 1,
                Quantity = 1,
                TradeType = TradeType.BUY,
            });

            repository.Update(stock);

            Assert.IsTrue(repository.GetBySymbol(symbol).Trades.Count > 0);
        }
    }
}
