using System;
using Sample.Domain.Command;
using Xunit;

namespace SampleTests.Domain.Command
{
   public class SetInvoiceSellDateCommandShould
   {
      [Fact]
      public void TrackPassedDate()
      {
         var date = DateTime.Now;
         var command = new SetInvoiceSellDateCommand(date);
         Assert.Equal(date, command.Date);
      }
   }
}