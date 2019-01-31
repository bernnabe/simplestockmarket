using SuperSimpleStockMarket.Net.Common.Patterns.Command;

namespace SuperSimpleStockMarket.Net.Domain.Commands
{
    /// <summary>
    /// CalculatePERatioCommand
    /// </summary>
    internal class CalculatePERatioCommand : ICommand
    {
        private readonly Stock _stock = null;
        private readonly double _price;

        public CalculatePERatioCommand(Stock stock, double price)
        {
            _stock = stock;
            _price = price;
        }
        public double Execute()
        {
            if (_stock.FixedDividend == 0) return 0;
            return (_price / _stock.FixedDividend);
        }
    }
}
