using Akedas.Accounting.Console.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console.Entites
{
  public enum AccountTransactionType
  {
    Deposit=100,
    WithDraw=200
  }

  // Hesap dökümü
  public class AccountTransaction
  {
    public Money Money { get; private set; }
    public int TransactionType { get; private set; } // +-
    public DateTime TransactionAt { get; private set; } // startDate endDate döküm

    public AccountTransaction(Money money, int transactionType)
    {
      TransactionAt = DateTime.Now;
      TransactionType = transactionType;
      Money = money;
    }

  }
}
