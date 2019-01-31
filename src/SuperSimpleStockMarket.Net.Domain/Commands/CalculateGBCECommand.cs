using SuperSimpleStockMarket.Net.Domain.Infraestructure;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Net.Domain.Commands
{
    /// <summary>
    /// CalculateGBCECommand
    /// </summary>
    internal class CalculateGBCECommand : ICommand
    {
        private readonly List<Stock> _Stocks = null;

        public CalculateGBCECommand(List<Stock> stocks)
        {
            _Stocks = stocks;
        }
        public double Execute()
        {
            double accumulator = 1;
            int tradesCount = 0;

            foreach (var stock in _Stocks)
            {
                foreach (var trade in stock.Trades)
                {
                    accumulator = accumulator * trade.Price;
                    tradesCount++;
                }
            }

            //if (tradesCount == 0) throw new Exception("No trades");
            if (tradesCount == 0) return 0;

            return Math.Pow(accumulator, (1 / tradesCount));
        }
    }
}
