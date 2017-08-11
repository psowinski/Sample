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
   }
}
