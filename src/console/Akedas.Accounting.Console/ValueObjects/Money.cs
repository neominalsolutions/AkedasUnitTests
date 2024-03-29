﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akedas.Accounting.Console.ValueObjects
{
  public record Money
  {
    public decimal Amount { get;  set; }
    public string Currency { get; set; }
    public Money(decimal amount,string currency)
    {
      Amount = amount;
      Currency = currency;
    }

    public string GetBalance()
    {
      return $"{Amount}/{Currency}";
    }


    
  }
}
