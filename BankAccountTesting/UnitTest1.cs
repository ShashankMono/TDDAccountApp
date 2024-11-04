using BankAccountTesting.Controller;
using BankAccountTesting.Exceptions;
using BankAccountTesting.Models;

namespace BankAccountTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            AccountManager.ListOfAccountsInBank.Add(new Account(101, "Ram", 5000));
            AccountManager.ListOfAccountsInBank.Add(new Account(102, "James", 2000));
            AccountManager.ListOfAccountsInBank.Add(new Account(103, "Adams", 600));
            AccountManager.ListOfAccountsInBank.Add(new Account(104, "Kallis", 800));
        }

        [TestCase(101,500,5500)]
        public void DepositeAmountToTheAccountWithId(int id,double amount,double ExpectedAmount)
        {
            Account account = AccountManager.FindAccountIsPresentInListOfBankAccounts(id);
            double actualAmount = AccountManager.DepositeIntoTheAccountWhichIsSentInTheParameter(account, amount);

            Assert.AreEqual(ExpectedAmount,actualAmount);
        }

        [TestCase(106)]
        public void GivesTheAccountInvalidExpectionForInvalidAccount(int id)
        {
            var excepthrows = Assert.Throws<AccountInvalidException>(() =>
                AccountManager.FindAccountIsPresentInListOfBankAccounts(id)

            );
            StringAssert.Contains("Account invalid!",excepthrows.Message);
        }

        [TestCase(101, -600)]
        public void DepositeAmountToTheAccountWithId(int id, double amount)
        {
            Account account = AccountManager.FindAccountIsPresentInListOfBankAccounts(id);
            var actualResponse = Assert.Throws<AmountInvalidException>(()=>
            AccountManager.DepositeIntoTheAccountWhichIsSentInTheParameter(account, amount));

            StringAssert.Contains("Amount invalid!", actualResponse.Message);
        }

        [TestCase(101, -600, "Amount invalid!")]
        
        public void WhileWithdrawFromAccountAmountIsNotValidExceptionIsGiven(int id, double amount,string ExpectedResult)
        {
            Account account = AccountManager.FindAccountIsPresentInListOfBankAccounts(id);
            var actualResponse = Assert.Throws<AmountInvalidException>(() =>
            AccountManager.WithdrawIntoAccountWhichIsSentInTheParameter(account, amount));

            StringAssert.Contains(ExpectedResult, actualResponse.Message);
        }

        [TestCase(103, 1000, "Insufficient balance!")]
        public void WhileWithdrawFromAccountAmountInSufficientExceptionIsGiven(int id, double amount, string ExpectedResult)
        {
            Account account = AccountManager.FindAccountIsPresentInListOfBankAccounts(id);
            var actualResponse = Assert.Throws<InsufficientAmountException>(() =>
            AccountManager.WithdrawIntoAccountWhichIsSentInTheParameter(account, amount));

            StringAssert.Contains(ExpectedResult, actualResponse.Message);
        }

        [TestCase(102, 700, 1300)]
        public void WithdrawAmountToTheAccountWithId(int id, double amount, double ExpectedAmount)
        {
            Account account = AccountManager.FindAccountIsPresentInListOfBankAccounts(id);
            double actualAmount = AccountManager.WithdrawIntoAccountWhichIsSentInTheParameter(account, amount);

            Assert.AreEqual(ExpectedAmount, actualAmount);
        }

        [TestCase(103, 104, 100,700,700)]
        public void TransferToTheAccountFromAccountToAccountRespectivelyToParameter(int ToId,int fromId, double amount, double ExpectedAmountInToAccont,double ExpectAmountInFromAccount)
        {
            Account toAccount = AccountManager.FindAccountIsPresentInListOfBankAccounts(ToId);
            Account fromAccount = AccountManager.FindAccountIsPresentInListOfBankAccounts(fromId);
            double actualAmountDeposite = AccountManager.DepositeIntoTheAccountWhichIsSentInTheParameter(toAccount,amount);
            double actualAmountInfromAccount = AccountManager.WithdrawIntoAccountWhichIsSentInTheParameter(fromAccount, amount);

            Assert.AreEqual(ExpectAmountInFromAccount, actualAmountInfromAccount);
            Assert.AreEqual(ExpectedAmountInToAccont, actualAmountDeposite);
        }

        [Test]
        public void TransferExceptionThrow()
        {
            string expectedString = "Account invalid!";
            Account toAccount = AccountManager.FindAccountIsPresentInListOfBankAccounts(102);
            var ExpectionString = Assert.Throws<AccountInvalidException>(
                ()=>AccountManager.FindAccountIsPresentInListOfBankAccounts(105));

            StringAssert.Contains(expectedString, ExpectionString.Message);
        }

    }
}