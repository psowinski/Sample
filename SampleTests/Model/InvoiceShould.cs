﻿using System;
using System.Linq;
using Sample.Domain.Event;
using Sample.Model;
using Xunit;

namespace SampleTests.Model
{
   public class InvoiceShould
   {
      private readonly Invoice invoice = new Invoice();

      [Fact]
      public void HandleInvoiceOpenedEvent()
      {
         var customerId = "123";
         this.invoice.Handle(new InvoiceOpenedEvent(customerId));
         Assert.Equal(customerId, this.invoice.CustomerId);
         Assert.True(this.invoice.IsOpen);
      }

      [Fact]
      public void HandleInvoiceItemAddedEvent()
      {
         var item = new InvoiceItem("1", 1m, 1u);
         this.invoice.Handle(new InvoiceItemAddedEvent(item));
         Assert.NotNull(this.invoice.Items.Any(x => x == item));
      }

      [Fact]
      public void CalculateTotalSum()
      {
         this.invoice.Handle(new InvoiceItemAddedEvent(new InvoiceItem("1", 1m, 3u)));
         this.invoice.Handle(new InvoiceItemAddedEvent(new InvoiceItem("2", 2.20m, 1u)));
         Assert.Equal(5.20m, this.invoice.TotalSum);
      }
   }
}
