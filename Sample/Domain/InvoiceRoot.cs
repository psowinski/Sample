using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Sample.Domain.Command;
using Sample.Domain.Event;
using Sample.Model;

namespace Sample.Domain
{
   public class InvoiceRoot : IObservable<IEvent>
   {
      public IInvoice CreateZeroState()
      {
         return new Invoice();
      }

      public void ExecuteCommand(IInvoice invoice, OpenInvoiceCommand openCommand)
      {
         if(!invoice.IsBlank) throw new InvalidOperationException("Only blank invoice can be opened.");
         Publish(new InvoiceOpenedEvent(openCommand.CustomerId));
      }

      private readonly Subject<IEvent> eventSubject = new Subject<IEvent>();

      private void Publish(IEvent @event) { this.eventSubject.OnNext(@event); }

      public IDisposable Subscribe(IObserver<IEvent> observer)
      {
         return this.eventSubject.Subscribe(observer);
      }
   }
}
