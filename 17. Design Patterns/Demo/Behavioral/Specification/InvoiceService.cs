namespace Specification
{
    using System;
    using System.Collections.Generic;

    public class InvoiceService : IInvoiceService
    {
        private readonly ICollection<Invoice> invoices; 

        public InvoiceService(int count = 20)
        {
            this.invoices = new List<Invoice>();
            var rand = new Random();
            for (int i = 1; i <= count; i++)
            {
                var invoice = new Invoice() { Id = i };
                if (rand.Next(0, 2) == 1)
                {
                    invoice.NoticeSent = true;
                }

                if (rand.Next(0, 2) == 1)
                {
                    invoice.SentForCollection = true;
                }

                invoice.PayDeadline = DateTime.Now.AddDays(rand.Next(-10, 10));

                this.invoices.Add(invoice);
            }
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            return this.invoices;
        }

        public void SendForCollection(Invoice invoice)
        {
            Console.WriteLine("Sending invoice for collection:");
            Console.WriteLine(invoice);
            Console.WriteLine();

            invoice.SentForCollection = true;
        }

        public void SendNotice(Invoice invoice)
        {
            Console.WriteLine("Sending notice for:");
            Console.WriteLine(invoice);
            Console.WriteLine();

            invoice.NoticeSent = true;
        }

        public bool IsSentForCollection(Invoice invoice)
        {
            return invoice.SentForCollection;
        }
    }
}