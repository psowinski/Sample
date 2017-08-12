using Sample.Model;

namespace SampleSpecs
{
   public class InvoiceItemRow
   {
      public string ProductId { get; set; }
      public decimal Price { get; set; }
      public uint Amount { get; set; }

      public InvoiceItem ToInvoiceItem() => new InvoiceItem(ProductId, Price, Amount);
   }
}