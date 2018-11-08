using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;
using CurrencyTrader;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        UrlTradeDataProvider urlTDP;
        public AdjustTradeDataProvider(String url)
        {
            urlTDP = new UrlTradeDataProvider(url);
        }
        

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeData = urlTDP.GetTradeData();
            List<string> newTradeData = new List<string>();
            foreach (string trade in tradeData)
            {
                String newTrade;
                if (trade.Contains("GBP"))
                {
                    newTrade = trade.Replace("GBP", "EUR");
                }
                else
                {
                    newTrade = trade;
                }
                newTradeData.Add(newTrade);
            }

            return newTradeData;
        }
    }
}
