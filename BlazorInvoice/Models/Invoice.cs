using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoice.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? CustomerName { get; set; }
        public Currency Currency { get; set; }
        public int Payment { get; set; }
        public int CustomerId { get; set; }
        /*
         This field represents the foreign key of the customer in the database.

       It only stores the customer identification number (eg: 1, 25, or 102) and not the complete customer data.

      Using this number, we can later reach the customer associated with the invoice.
         */
        public Customer? Customer { get; set; }
       
        public int DollarBoDinar { get; set; } 

        /*
         * 
         This field represents the relationship between the invoice and the customer as an object.

Its type Customer? Customer can be existing or nullable.

It allows you to access customer data directly from the invoice instead of just the identification number.
         */
        public List<InvoiceItem> InvoiceItems { get; set; }//الفاتورة تحتوي عدة أصناف
        public List<Payment> Payments { get; set; }//الفاتورة يمكن أن تحتوي عدة دفعات
    }
}
