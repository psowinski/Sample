using System;
using System.Reactive.Subjects;
using Sample.Domain.Command;
using Sample.Domain.Event;

namespace Sample.Domain
{
   public abstract class AggregateRoot<TState, TCommandHandler> : IObservable<IEvent<TState>>
   {
      public abstract TState Zero();

      public abstract void Execute(TState state, ICommand<TState, TCommandHandler> command);

      public void Apply(TState state, IEvent<TState> @event) => @event.Visit(state);

      private readonly Subject<IEvent<TState>> eventSubject = new Subject<IEvent<TState>>();

      protected void Publish(IEvent<TState> @event) => this.eventSubject.OnNext(@event);

      protected void RiseError(Exception exception) => this.eventSubject.OnError(exception);

      public IDisposable Subscribe(IObserver<IEvent<TState>> observer) => this.eventSubject.Subscribe(observer);
   }
}