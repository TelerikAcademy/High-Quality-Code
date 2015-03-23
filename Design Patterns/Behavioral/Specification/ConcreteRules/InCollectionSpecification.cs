namespace Specification.ConcreteRules
{
    using Specification.BaseLogic;

    public class SentForCollectionSpecification : ISpecification<Invoice>
    {
        private readonly IInvoiceService service;

        public SentForCollectionSpecification(IInvoiceService service)
        {
            this.service = service;
        }

        public bool IsSatisfiedBy(Invoice invoice)
        {
            return this.service.IsSentForCollection(invoice);
        }
    }
}
