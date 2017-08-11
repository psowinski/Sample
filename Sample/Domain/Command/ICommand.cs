namespace Sample.Domain.Command
{
   public interface ICommand<TState, TVisitor>
   {
      void Visit(TVisitor visitor, TState state);
   }
}