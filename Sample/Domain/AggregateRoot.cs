
using System;
using System.Reactive.Subjects;

namespace Sample.Domain
{
   public abstract class AggregateRoot<TState, TEvent> : IObservable<TEvent>
   {
      public abstract TState CreateZeroState();

      private readonly Subject<TEvent> eventSubject = new Subject<TEvent>();

      protected void Publish(TEvent @event)
      {
         this.eventSubject.OnNext(@event);
      }

      public IDisposable Subscribe(IObserver<TEvent> observer)
      {
         return this.eventSubject.Subscribe(observer);
      }
   }
}