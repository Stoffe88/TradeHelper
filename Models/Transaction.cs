using System;
using System.Collections.Generic;

namespace TradeHelper.Models
{
    public enum TransactionType { None, Deposit, Withdraw, Buy, Sell, Dividend, Signal }

    public class Transaction
    {
        public int Id { get; protected set; }
        public DateTime Date { get; protected set; }
        public TransactionType Type { get; protected set; }        
        public decimal Amount { get; protected set; }

        public Transaction(TransactionType type, DateTime date, decimal amount)
        {
            Type = type;
            Date = date;
            Amount = amount;
        }
    }
}
