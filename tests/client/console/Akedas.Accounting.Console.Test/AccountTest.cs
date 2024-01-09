using Xunit;

namespace Akedas.Accounting.Console.Test
{
  public class AccountTest
  {
    [Fact] // Fact TestMethodarýna dýþarýdan parametre göndermeyi desteklemez.
    // Teory tipi ise dýþarýdan parametre gönderek yapýlacak iþlemleri tesil eder.
    public void BalanceUnSufficent()
    {
      // Arrange => Servisin hazýrlanmasý
      Akedas.Accounting.Console.Entites.Account account = new Entites.Account("4234-23432-324324");




      // Act => eyleme geçilemesi
      account.Deposit(6000);
      account.WithDraw(5000);


      // Assert => methodun beklenen sonucu ile test sonrasý sonuc beklenen sonuca eþit mi, ya geçtik yada kaldýk.
      // actual => account.Balance.Amount þuanki durum
      // expected => beklenilen durum
      Assert.Equal(5500, account.Balance.Amount); // eþit ise testen geçtim.

    }


    [Theory]
    [InlineData(300,700)]
    [InlineData(500, 500)]
    [InlineData(750, 270)]
    public void WithDrawWithParameters(decimal amount,decimal balance)
    {
     

      // Arrange => Servisin hazýrlanmasý
      Akedas.Accounting.Console.Entites.Account account = new Entites.Account("4234-23432-324324");

      // Act => eyleme geçilemesi
      account.Deposit(1000);  // 1000 TL balance olduðunda
      account.WithDraw(amount); // dinamik kýsým

      // Assert =>
      Assert.True((1000 - balance) == amount);

    }


  }
}