namespace Sample.Domain
{
   public interface ICommandHandler<TState, TCommand>
   {
      void Handle(TState state, TCommand command);
   }
}