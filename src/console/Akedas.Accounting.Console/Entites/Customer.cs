using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console.Entites
{
  public class Customer
  {
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public List<Account> Accounts { get; set; } 

    public Customer(string firstName,string lastName)
    {
      FirstName = firstName;
      LastName = lastName;
      Accounts = new List<Account>();
    }

    public void OpenAccount(string accountNumber)
    {
      Accounts.Add(new Account(accountNumber));
    }

    public void CloseAccount(string accountNumber, string closeReason)
    {
      var account = Accounts.Find(x => x.AccountNumber == accountNumber);
      
      if(account is not null)
      {
        account.Close(closeReason);
      } 
      else
      {
        throw new Exception("Hesap bulunamadı");
      }
    }


    public Account GetCurrentAccount(string accountNumber)
    {
      var account = Accounts.Find(x => x.AccountNumber == accountNumber && x.Closed == false);

      if(account is not null)
      {
        return account;
      }
      else
      {
        throw new Exception("Account Geçerli değildir");
        // return null; yanlış bir yaklaşım
      }

    }

  }
}
