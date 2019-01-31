using SuperSimpleStockMarket.Net.Common.Patterns.Command;
using System;

namespace SuperSimpleStockMarket.Net.Domain.Commands
{
    /// <summary>
    /// CalculateDividenYieldCommand 
    /// </summary>
    internal class CalculateDividenYieldCommand : ICommand
    {
        private readonly Stock _stock = null;
        private readonly double _price;

        private const string _COMMON = "COMMON";
        private const string _PREFERRED = "PREFERRED";

        public CalculateDividenYieldCommand(Stock stock, double price)
        {
            _stock = stock;
            _price = price;
        }

        public double Execute()
        {
            if (_price == 0) return 0;

            //TODO: Podría ir en un Strategy 
            switch (_stock.Type)
            {
                case _COMMON:
                    return DividendYieldCommon();
                case _PREFERRED:
                    return DividendYieldPreferred();
                default:
                    throw new ArgumentException("Unknow stock type");
            }
        }

        private double DividendYieldCommon()
        {
            return _stock.LastDividend / _price;
        }

        private double DividendYieldPreferred()
        {
            return (_stock.FixedDividend * _stock.ParValue) / _price;
        }
    }
}
