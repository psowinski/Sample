namespace Sample.Model
{
   internal class Invoice : IInvoice
   {
      public Invoice()
      {
         IsBlank = true;
      }

      public bool IsBlank { get; }
   }
}