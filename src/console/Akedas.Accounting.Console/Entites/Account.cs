using Akedas.Accounting.Console.Exceptions;
using Akedas.Accounting.Console.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console.Entites
{
  public class Account
  {
    public string AccountNumber { get; private set; }
    public string? CloseReason { get; private set; }

    public DateTime? ClosedAt { get; private set; }
    public bool Closed { get; private set; }

    public Money Balance { get; private set; } // value Object

    public List<AccountTransaction> Transactions { get; set; }

    public Account(string accountNumber)
    {
      AccountNumber = accountNumber;
      Balance = new Money(amount: 0, currency: "TL");
      Transactions = new List<AccountTransaction>();
    }

    public void Close(string closeReason)
    {
      CloseReason = closeReason;
      ClosedAt = DateTime.Now;
      Closed = true;
    }

    /// <summary>
    /// Para yatırma
    /// </summary>
    /// <param name="amount"></param>
    public void Deposit(decimal amount)
    {
      Balance.Amount += amount;

      Transactions.Add(new AccountTransaction(new Money(amount,"TL"), (int)AccountTransactionType.Deposit));

      //double number = double.Parse("10.4"); // 10.4
      //int number2 = Convert.ToInt32(10.2); // 10

    }

    #region WithDraw
    /// <summary>
    /// günlük para çekme limit 5000 Tl olsun
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="Exception"></exception>
    public void WithDraw(decimal amount) // Bussiness Rules
    {
      decimal dailyCost = Transactions.Where(x => x.TransactionAt.Date == DateTime.Now.Date && x.TransactionType == (int)AccountTransactionType.WithDraw).Sum(x=> x.Money.Amount);


      if(amount > Balance.Amount) // Test Case 1 (BalanceUnSufficentTest)
      {
        throw new BalanceUnSufficientException();
      }
      else if(Closed) // Test Case 2 (AccountClosedTest)
      {
        throw new Exception("Hesap kapalı para çekilemez");
      } 
      else if((dailyCost + amount > 5000)) // Test Case 3 (DailyLimitTest)
      {
        throw new Exception("Günlük para çekme limitini aştınız");
      }
      else
      {
        Balance.Amount -= amount;
        Transactions.Add(new AccountTransaction(new Money(amount, "TL"), (int)AccountTransactionType.WithDraw));
      }
    }

    #endregion

  }
}
