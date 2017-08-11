
using System;
using System.Reactive.Subjects;
using Sample.Domain.Event;

namespace Sample.Domain
{
   public abstract class AggregateRoot<TState> : IObservable<IEvent<TState>>
   {
      public abstract TState CreateZeroState();

      //public abstract void ExecuteCommand(TState state, TCommand command);

      public void ApplyEvent(TState state, IEvent<TState> @event)
      {
         @event.Visit(state);
      }

      private readonly Subject<IEvent<TState>> eventSubject = new Subject<IEvent<TState>>();

      protected void Publish(IEvent<TState> @event)
      {
         this.eventSubject.OnNext(@event);
      }

      public IDisposable Subscribe(IObserver<IEvent<TState>> observer)
      {
         return this.eventSubject.Subscribe(observer);
      }
   }
}