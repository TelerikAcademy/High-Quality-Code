namespace Specification.ConcreteRules
{
    using Specification.BaseLogic;

    public class NoticeSentSpecification : ISpecification<Invoice>
    {
        public bool IsSatisfiedBy(Invoice entity)
        {
            return entity.NoticeSent;
        }
    }
}
