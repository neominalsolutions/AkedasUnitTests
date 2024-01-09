using Akedas.Accounting.Console.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Customer customer = new Customer(firstName:"Ali",lastName:"Tan");
      customer.OpenAccount("6656-345435-345345-4354345");
      // customer.CloseAccount("6656-345435-345345-4354345", "Başka bir firmaya geçiş");

      // Domain Centric, Model Centric
      // nesne statelerini günceller
      var account = customer.GetCurrentAccount("6656-345435-345345-4354345");
      account.WithDraw(5000); // 6000 => 1000
      account.Deposit(30000);

      // Data Centric
      // accountService = new AccountService();
      // var account = accountService.Find("6656-345435-345345-4354345");
      // accountService.WithDraw(account,5000);

      // accountRepo = new AccountRepo();
      // accountRepo.save(account);

    }
  }
}
