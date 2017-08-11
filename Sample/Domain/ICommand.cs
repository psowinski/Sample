namespace Sample.Domain
{
   public interface ICommand<TState, TVisitor>
   {
      void Visit(TVisitor visitor, TState state);
   }
}