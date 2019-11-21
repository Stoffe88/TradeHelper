using System;
using System.Collections.Generic;

namespace TradeHelper.Models
{
    public class Stock
    {
        public int Id { get; protected set; }
        public string Name { get; set; }        
        public bool IsRemoved { get; private set; }
        public int Count { get; protected set; }

        public decimal TotalCost { get; protected set; }
        public decimal Cost => Count == 0 ? 0 : TotalCost / Count;
        public decimal Profit { get; protected set; }

        public DateTime ValueUpdated { get; set; }
        public decimal Value { get; set; }
        public decimal TotalValue => Value * Count;

        public bool NameIsEdited { get; set; }
        public bool ValueIsEdited { get; set; }

        public List<StockTransaction> Transactions { get; protected set; } = new List<StockTransaction>();

        public Stock(string name) => Name = name;        

        public void Remove() => IsRemoved = true;
        public void Restore() => IsRemoved = false;

        public void Sell(DateTime date, int count, decimal amount)
        {
            decimal cost = Cost * count;
            TotalCost -= cost;
            Profit += amount - cost;
            Count -= count;

            Transactions.Add(new StockTransaction(TransactionType.Sell, date, amount, this.Id, -count));
        }

        public void Buy(DateTime date, int count, decimal amount)
        {
            TotalCost += amount;
            Count += count;

            Transactions.Add(new StockTransaction(TransactionType.Buy, date, -amount, this.Id, count));
        }

        //public ICollection<ClosingResult> ClosingResults { get; protected set; }

        //public void Update(double openValue, double closeValue, double maxValue, double minValue, int rsi, double sma)
        //{
        //    ClosingResults.Add(new ClosingResult(this.Id, DateTime.Today, openValue, closeValue, maxValue, minValue, rsi, sma));


        //}
    }
}
