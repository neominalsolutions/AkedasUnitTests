using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console.Exceptions
{
  public class BalanceUnSufficientException:Exception
  {
    public BalanceUnSufficientException(string message = "Bakiye yetersiz") : base(message)
    {

    }
  }
}
