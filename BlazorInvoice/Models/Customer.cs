using BlazorInvoice.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoice.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }




        [NotMapped]
        public decimal TotalPaid { get; set; }

        [NotMapped]
        public decimal Remaining { get; set; }




        public List<Invoice> Invoices { get; set; }//One customer can have multiple invoices
        public Customer()
        {
            Invoices = new List<Invoice>();
        }

        // الجديد
       
    }
}

/*
The constructor is executed when a new Customer object is created, and it initializes Invoices with an empty list.
Without this initialization, Invoices would remain null, and calling Invoices.Add(...) would attempt to use
an object that does not exist in memory, resulting in a NullReferenceException.

so without this     
 public Customer()
        {
            Invoices = new List<Invoice>();
        }


The pronlem appear in this c.Invoices.Add(new Invoice()); as  c.Invoices == null

Customer c = new Customer();
c.Invoices == null
c.Invoices.Add(new Invoice());
*/