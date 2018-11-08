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
                String newTrade = trade.Replace("GBP", "EUR");
                
                newTradeData.Add(newTrade);
            }

            return newTradeData;
        }
    }
}
