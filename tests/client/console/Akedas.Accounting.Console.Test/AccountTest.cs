using Xunit;

namespace Akedas.Accounting.Console.Test
{
  public class AccountTest
  {
    [Fact] // Fact TestMethodar�na d��ar�dan parametre g�ndermeyi desteklemez.
    // Teory tipi ise d��ar�dan parametre g�nderek yap�lacak i�lemleri tesil eder.
    public void BalanceUnSufficent()
    {
      // Arrange => Servisin haz�rlanmas�
      Akedas.Accounting.Console.Entites.Account account = new Entites.Account("4234-23432-324324");




      // Act => eyleme ge�ilemesi
      account.Deposit(6000);
      account.WithDraw(5000);


      // Assert => methodun beklenen sonucu ile test sonras� sonuc beklenen sonuca e�it mi, ya ge�tik yada kald�k.
      // actual => account.Balance.Amount �uanki durum
      // expected => beklenilen durum
      Assert.Equal(5500, account.Balance.Amount); // e�it ise testen ge�tim.

    }


    [Theory]
    [InlineData(300,700)]
    [InlineData(500, 500)]
    [InlineData(750, 270)]
    public void WithDrawWithParameters(decimal amount,decimal balance)
    {
     

      // Arrange => Servisin haz�rlanmas�
      Akedas.Accounting.Console.Entites.Account account = new Entites.Account("4234-23432-324324");

      // Act => eyleme ge�ilemesi
      account.Deposit(1000);  // 1000 TL balance oldu�unda
      account.WithDraw(amount); // dinamik k�s�m

      // Assert =>
      Assert.True((1000 - balance) == amount);

    }


  }
}