using SuperSimpleStockMarket.Net.Common.Service;
using SuperSimpleStockMarket.Net.Domain;
using SuperSimpleStockMarket.Net.Domain.Calculator;
using SuperSimpleStockMarket.Net.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Net.Service
{
    /// <summary>
    /// Example Assignment – Super Simple Stock Market
    /// </summary>
    public class StockService : IStockService
    {
        /// <summary>
        /// i.	Given any price as input, calculate the dividend yield
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public OperationResult<double> CalculateDividendYield(string symbol, double price)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol is empty");

                Stock stock = new StockRepository().GetBySymbol(symbol);

                if (stock == null) throw new ArgumentException("stock doesn't exists");
                if (price <= 0) throw new ArgumentException("price must be grater than zero");

                return OperationResult<double>.Ok(Calculator.CalculateDividendYield(stock, price));
            }
            catch (Exception ex)
            {
                return OperationResult<double>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// ii.	Given any price as input,  calculate the P/E Ratio
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public OperationResult<double> CalculatePERatio(string symbol, double price)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol is empty");

                Stock stock = new StockRepository().GetBySymbol(symbol);

                if (stock == null) throw new ArgumentException("stock doesn't exists");
                if (price <= 0) throw new ArgumentException("price must be grater than zero");

                return OperationResult<double>.Ok(Calculator.CalculatePERatio(stock, price));
            }
            catch (Exception ex)
            {
                return OperationResult<double>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// iv.	Calculate Volume Weighted Stock Price based on trades in past  5 minutes
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public OperationResult<double> CalculateVolumeWeightedPrice(string symbol)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol is empty");

                List<Trade> trades = new TradeRepository().GetLast5MinutesTradesBySymbol(symbol, DateTime.Now);

                if (trades == null || !trades.Any()) throw new ArgumentException("no trades to calculate");

                return OperationResult<double>.Ok(Calculator.CalculateVolumeWeightedPrice(trades));
            }
            catch (Exception ex)
            {
                return OperationResult<double>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// b.	Calculate the GBCE All Share Index using the geometric mean of the Volume Weighted Stock Price for all stocks
        /// </summary>
        /// <returns></returns>
        public OperationResult<double> CalculateGBCE()
        {
            try
            {
                List<Stock> stocks = new StockRepository().GetAll();

                return OperationResult<double>.Ok(Calculator.CalculateGBCE(stocks));
            }
            catch (Exception ex)
            {
                return OperationResult<double>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// iii.	Record a trade, with timestamp, quantity, buy or sell indicator and price
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tradeType"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public OperationResult AddTrade(string symbol, TradeType tradeType, double price, int quantity)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("symbol is empty");

                StockRepository repository = new StockRepository();
                Stock stock = repository.GetBySymbol(symbol);

                if (stock == null) throw new ArgumentException("stock doesn't exists");
                if (price <= 0) throw new ArgumentException("price must be grater than zero");
                if (quantity <= 0) throw new ArgumentException("quantity must be grater than zero");

                stock.AddTrade(new Trade
                {
                    DateTime = DateTime.Now,
                    Price = price,
                    TradeType = tradeType,
                    Quantity = quantity
                });

                repository.Update(stock);

                return OperationResult.Ok();
            }
            catch (Exception ex)
            {
                return OperationResult.Fail(ex.Message);
            }
        }
    }
}
