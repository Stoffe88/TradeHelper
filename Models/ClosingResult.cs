using System;

namespace TradeHelper.Models
{
    public class ClosingResult
    {
        public int Id { get; protected set; }
        public DateTime Date { get; protected set; }

        public int StockId { get; protected set; }

        public double OpenValue { get; protected set; }
        public double MaxValue { get; protected set; }
        public double MinValue { get; protected set; }        
        public double CloseValue { get; protected set; }

        public int RSI { get; protected set; }
        public double SMA { get; protected set; }

        public ClosingResult(int stockId,
                             DateTime date,
                             double openValue,
                             double closeValue,
                             double maxValue,
                             double minValue,
                             int rsi,
                             double sma)
        {
            StockId = stockId;
            Date = date;

            OpenValue = openValue;
            CloseValue = closeValue;
            MaxValue = maxValue;
            MinValue = minValue;

            RSI = rsi;
            SMA = sma;
        }
    }
}
