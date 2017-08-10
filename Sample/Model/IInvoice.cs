namespace Sample.Model
{
   public interface IInvoice
   {
      bool IsBlank { get; }
      bool IsOpen { get; }
      string CustomerId { get; }
   }
}