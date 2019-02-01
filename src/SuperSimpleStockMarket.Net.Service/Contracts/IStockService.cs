using SuperSimpleStockMarket.Net.Common.Service;
using SuperSimpleStockMarket.Net.Domain;

namespace SuperSimpleStockMarket.Net.Service.Contracts
{
    public interface IStockService
    {
        /// <summary>
        /// i.	Given any price as input, calculate the dividend yield
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        OperationResult<double> CalculateDividendYield(string symbol, double price);

        /// <summary>
        /// ii.	Given any price as input,  calculate the P/E Ratio
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        OperationResult<double> CalculatePERatio(string symbol, double price);

        /// <summary>
        /// iv.	Calculate Volume Weighted Stock Price based on trades in past  5 minutes
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        OperationResult<double> CalculateVolumeWeightedPrice(string symbol);

        /// <summary>
        /// b.	Calculate the GBCE All Share Index using the geometric mean of the Volume Weighted Stock Price for all stocks
        /// </summary>
        /// <returns></returns>
        OperationResult<double> CalculateGBCE();

        /// <summary>
        /// iii.	Record a trade, with timestamp, quantity, buy or sell indicator and price
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tradeType"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        OperationResult AddTrade(string symbol, TradeType tradeType, double price, int quantity);
    }
}
