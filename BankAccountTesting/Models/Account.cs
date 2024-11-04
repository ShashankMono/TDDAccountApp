using BankAccountTesting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Models
{
    internal class Account
    {
        public int AccountId { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; set; }
        private double Min_Balance { get; set; } = 500;
        public Account(int id, string name, double balance)
        {
            AccountId = id;
            AccountHolderName = name;
            if (balance < Min_Balance)
                Balance = Min_Balance;
            else
                Balance = balance;
            
        }

        public void DepositeAddsAmountToBankAccount(double amount)
        {
            Balance += amount;
        }

        public void WithdrawDeductsAmountFromAccount(double amount)
        {
            if (Balance - amount < 500)
                throw new InsufficientAmountException("Insufficient balance!");
            Balance -= amount;
        }
    }
}
