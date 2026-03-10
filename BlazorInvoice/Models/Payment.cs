using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoice.Models
{
    public enum Currency
    {
        USD,
        DINAR
        /*
         هذا ممتاز لأنه:

يمنع إدخال نص عشوائي

يخزن كـ int في قاعدة البيانات
         */
    }
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public bool Paid { get; set; }
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        [NotMapped]
        public bool IsEdited { get; set; } = false;
    }
}
