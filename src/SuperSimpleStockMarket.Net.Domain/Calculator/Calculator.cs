using SuperSimpleStockMarket.Net.Domain.Commands;
using SuperSimpleStockMarket.Net.Domain.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Net.Domain.Calculator
{
    public class Calculator
    {
        public static double CalculateDividendYield(Stock stock, double price)
        {
            ICommand calculator = new CalculateDividenYieldCommand(stock, price);
            return calculator.Execute();
        }

        public static double CalculatePERatio(Stock stock, double price)
        {
            ICommand calculator = new CalculatePERatioCommand(stock, price);
            return calculator.Execute();
        }

        public static double CalculateVolumeWeightedPrice(List<Trade> trades)
        {
            ICommand calculator = new CalculateVolumeWeightedStockPriceCommand(trades);
            return calculator.Execute();
        }

        public static double CalculateGBCE(List<Stock> stocks)
        {
            ICommand calculator = new CalculateGBCECommand(stocks);
            return calculator.Execute();
        }
    }
}
