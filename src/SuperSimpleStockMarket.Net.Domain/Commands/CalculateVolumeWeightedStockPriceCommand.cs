using SuperSimpleStockMarket.Net.Domain.Infraestructure;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStockMarket.Net.Domain.Commands
{
    internal class CalculateVolumeWeightedStockPriceCommand : ICommand
    {
        private readonly List<Trade> _trades = null;
        public CalculateVolumeWeightedStockPriceCommand(List<Trade> trades)
        {
            _trades = trades;
        }

        public double Execute()
        {
            double sumPriceQuantity = _trades.Sum(c => (c.Price * c.Quantity));
            int sumQuantity = _trades.Sum(c => c.Quantity);

            if (sumQuantity == 0) return 0;

            return sumPriceQuantity / sumQuantity;
        }
    }
}
