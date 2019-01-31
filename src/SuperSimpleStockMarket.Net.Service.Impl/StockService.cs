using SuperSimpleStockMarket.Net.Domain;
using SuperSimpleStockMarket.Net.Domain.Commands;
using SuperSimpleStockMarket.Net.Domain.Infraestructure;
using SuperSimpleStockMarket.Net.Repository.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using SuperSimpleStockMarket.Net.Domain.Calculator;

namespace SuperSimpleStockMarket.Net.Service.Impl
{
    public class StockService : IStockService
    {
        public double CalculateDividendYield(string symbol, double price)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol");

            Stock stock = new StockRepository().GetBySymbol(symbol);

            if (stock == null) throw new ArgumentException("stock");
            if (price <= 0) throw new ArgumentException("price");

            return Calculator.CalculateDividendYield(stock, price);
        }

        public double CalculatePERatio(string symbol, double price)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol");

            Stock stock = new StockRepository().GetBySymbol(symbol);

            if (stock == null) throw new ArgumentException("stock");
            if (price <= 0) throw new ArgumentException("price");

            return Calculator.CalculatePERatio(stock, price);
        }

        public double CalculateVolumeWeightedPrice(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol");

            List<Trade> trades = new TradeRepository().GetLast5MinutesTradesBySymbol(symbol, DateTime.Now);

            if (trades == null || !trades.Any()) return 0;

            return Calculator.CalculateVolumeWeightedPrice(trades);
        }

        public double CalculateGBCE()
        {
            List<Stock> stocks = new StockRepository().GetAll();

            return Calculator.CalculateGBCE(stocks);
        }

        public void AddTrade(string symbol, TradeType tradeType, double price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol");

            StockRepository repository = new StockRepository();
            Stock stock = repository.GetBySymbol(symbol);

            if (stock == null) throw new ArgumentException("stock");
            if (price <= 0) throw new ArgumentException("price");
            if (quantity <= 0) throw new ArgumentException("quantity");

            stock.AddTrade(new Trade
            {
                 DateTime = DateTime.Now,
                 Price = price,
                 TradeType = tradeType,
                 Quantity = quantity
            });

            repository.Update(stock);
        }
    }
}
