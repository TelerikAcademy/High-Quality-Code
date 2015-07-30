namespace Specification
{
    using System;

    using Specification.BaseLogic;
    using Specification.ConcreteRules;

    public static class Program
    {
        public static void Main()
        {
            var invoiceService = new InvoiceService();

            var overDue = new OverDueSpecification();
            var noticeSent = new NoticeSentSpecification();
            var inCollection = new SentForCollectionSpecification(invoiceService);

            // Example of specification pattern logic chaining
            var sendToCollection = overDue.And(noticeSent).And(inCollection.Not());
            foreach (var invoice in invoiceService.GetAllInvoices())
            {
                if (sendToCollection.IsSatisfiedBy(invoice))
                {
                    invoiceService.SendForCollection(invoice);
                }
            }
            
            Console.WriteLine(new string('-', 60));

            var sendNotice = overDue.And(noticeSent.Not()).And(inCollection.Not());
            foreach (var invoice in invoiceService.GetAllInvoices())
            {
                if (sendNotice.IsSatisfiedBy(invoice))
                {
                    invoiceService.SendNotice(invoice);
                }
            }
        }
    }
}
