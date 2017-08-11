namespace Sample.Domain.Event
{
   public interface IEvent<T>
   {
      void Visit(T visitable);
   }
}