using BankAccountTesting.Exceptions;
using BankAccountTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountTesting.Controller
{
    internal class AccountManager
    {
        public static List<Account> ListOfAccountsInBank = new List<Account>();
        public static Account FindAccountIsPresentInListOfBankAccounts(int id)
        {
            Account account = ListOfAccountsInBank.Where(account => account.AccountId == id).FirstOrDefault();
            if (account == null)
                throw new AccountInvalidException("Account invalid!");
            return account;
        }

        public static double DepositeIntoTheAccountWhichIsSentInTheParameter(Account account,double amount)
        {
            if (amount < 1)
                throw new AmountInvalidException("Amount invalid!");
            account.DepositeAddsAmountToBankAccount(amount);
            return account.Balance;
        }

        public static double WithdrawIntoAccountWhichIsSentInTheParameter(Account account,double amount)
        {
            if (amount < 1)
                throw new AmountInvalidException("Amount invalid!");
            account.WithdrawDeductsAmountFromAccount(amount);
            return account.Balance;
        }

        //public static string TransferAmountToAnotherAccount(Account fromAccount,Account toAccount,double amount)
        //{
        //    DepositeIntoTheAccountWhichIsSentInTheParameter(toAccount, amount);
        //    WithdrawIntoAccountWhichIsSentInTheParameter(fromAccount, amount);
        //    return "Transfer successfully";
        //}
    }
}


