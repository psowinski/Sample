namespace Sample.Model
{
   public interface IEventHandler<TEvent>
   {
      void Handle(TEvent @event);
   }
}