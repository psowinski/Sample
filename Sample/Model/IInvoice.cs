namespace Sample.Model
{
   public interface IInvoice
   {
      bool IsBlank { get; }
      string CustomerId { get; }
   }
}