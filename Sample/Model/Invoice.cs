namespace Sample.Model
{
   internal class Invoice : IInvoice
   {
      public bool IsOpen { get; private set; }
   }
}