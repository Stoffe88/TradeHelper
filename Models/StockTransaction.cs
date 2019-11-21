using System;

namespace TradeHelper.Models
{
    public class StockTransaction : Transaction
    {
        public int StockId { get; protected set; }
        public Stock Stock { get; protected set; }

        public int StockCount { get; protected set; }

        public StockTransaction(TransactionType type, DateTime date, decimal amount, int stockId, int stockCount)
            : base(type, date, amount)
        {
            StockId = stockId;
            StockCount = stockCount;
        }
    }
}
