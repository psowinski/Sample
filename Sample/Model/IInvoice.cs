﻿using System;
using System.Collections.ObjectModel;
using Sample.Domain.Event;

namespace Sample.Model
{
   public interface IInvoice : IEventHandler<InvoiceOpenedEvent>,
                               IEventHandler<InvoiceItemAddedEvent>,
                               IEventHandler<InvoiceSellDateSetEvent>,
                               IEventHandler<InvoiceClosedEvent>
   {
      bool IsBlank { get; }
      bool IsOpen { get; }
      string CustomerId { get; }
      ReadOnlyCollection<InvoiceItem> Items { get; }
      decimal TotalSum { get; }
      DateTime Date { get; }
   }
}