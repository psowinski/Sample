using System;

namespace Sample.Model
{
   public class InvoiceItem : IEquatable<InvoiceItem>
   {
      public string ProductId { get; }
      public decimal Price { get; }
      public uint Amount { get; }

      public InvoiceItem(string productId, decimal price, uint amount)
      {
         ProductId = productId;
         Price = price;
         Amount = amount;
      }

      public bool Equals(InvoiceItem other)
      {
         if (ReferenceEquals(null, other)) return false;
         if (ReferenceEquals(this, other)) return true;
         return string.Equals(ProductId, other.ProductId) && Price == other.Price && Amount == other.Amount;
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((InvoiceItem) obj);
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = ProductId != null ? ProductId.GetHashCode() : 0;
            hashCode = (hashCode * 397) ^ Price.GetHashCode();
            hashCode = (hashCode * 397) ^ (int) Amount;
            return hashCode;
         }
      }

      public static bool operator ==(InvoiceItem obj1, InvoiceItem obj2)
      {
         return Equals(obj1, obj2);
      }

      public static bool operator !=(InvoiceItem obj1, InvoiceItem obj2)
      {
         return !Equals(obj1, obj2);
      }
   }
}