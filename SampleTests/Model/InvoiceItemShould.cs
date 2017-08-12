using Sample.Model;
using Xunit;

namespace SampleTests.Model
{
   public class InvoiceItemShould
   {
      [Fact]
      public void TrackConstuctorArguments()
      {
         var item = new InvoiceItem("123", 321m, 222u);
         Assert.Equal("123", item.ProductId);
         Assert.Equal(321m, item.Price);
         Assert.Equal(222u, item.Amount);
      }

      [Theory]
      [InlineData("1", 1, 1, "1", 1, 1, true)]
      [InlineData("a", 3, 5, "a", 3, 5, true)]
      [InlineData("1", 1, 1, "2", 1, 1, false)]
      [InlineData("1", 1, 1, "1", 2, 1, false)]
      [InlineData("1", 1, 1, "1", 1, 2, false)]
      public void BeEqualBySimilarity(
         string productId1,
         decimal price1,
         uint amount1,
         string productId2,
         decimal price2,
         uint amount2,
         bool expected)
      {
         var sut = new InvoiceItem(productId1, price1, amount1);
         var other = new InvoiceItem(productId2, price2, amount2);

         Assert.Equal(expected, sut.Equals(other));
         Assert.Equal(expected, sut.Equals((object)other));
         Assert.Equal(expected, sut == other);
         Assert.Equal(expected, !(sut != other));
         Assert.Equal(expected, sut.GetHashCode() == other.GetHashCode());
      }

   }
}
