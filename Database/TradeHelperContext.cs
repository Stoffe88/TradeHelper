using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TradeHelper.Database.EntityConfigurations;
using TradeHelper.Models;

namespace TradeHelper.Database
{
    public class TradeHelperContext : DbContext
    {
        public DbSet<Stock> Stocks { get; private set; }
        public DbSet<Transaction> Transactions { get; private set; }
        public DbSet<StockTransaction> StockTransactions { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TradeHelper;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new StockTransactionConfiguration());
        }

        public Stock FindStock(string name)
        {
            return Stocks.FirstOrDefault(stock => stock.Name == name);
        }

        public Stock FindStock(int id)
        {
            return Stocks.FirstOrDefault(stock => stock.Id == id);
        }

        public bool AddStock(string name)
        {
            var stock = FindStock(name);
            bool? isRemoved = stock?.IsRemoved;
            
            if (isRemoved == null)
            {
                Stocks.Add(new Stock(name));
                return true;
            }
            else if(isRemoved == true)
            {
                stock.Restore();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddTransaction(TransactionType type, DateTime date, decimal amount)
        {
            if(type == TransactionType.Withdraw) 
            {
                amount = -amount;
            }

            Transactions.Add(new Transaction(type, date, amount));            
        }

        public List<Transaction> LatestTransactions(int numberOfTransactions)
        {
            var transactionList = new List<Transaction>();

            transactionList.AddRange(Transactions
                .Where(transaction => !(transaction is StockTransaction))
                .Take(numberOfTransactions));

            transactionList.AddRange(StockTransactions.Take(numberOfTransactions)
                .Include(transaction => transaction.Stock));

            return transactionList
                .OrderByDescending(transaction => transaction.Date)
                .Take(numberOfTransactions).ToList();
        }

        public List<Stock> StockRegistry()
        {
            return Stocks.Where(stock => !stock.IsRemoved).OrderBy(stock => stock.Name).ToList();
        }

        public List<Stock> RemovedStocks()
        {
            return Stocks.Where(stock => stock.IsRemoved).ToList();
        }
    }
}
