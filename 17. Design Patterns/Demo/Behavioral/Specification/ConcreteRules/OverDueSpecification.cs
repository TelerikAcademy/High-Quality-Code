namespace Specification.ConcreteRules
{
    using System;

    using Specification.BaseLogic;

    public class OverDueSpecification : ISpecification<Invoice>
    {
        public bool IsSatisfiedBy(Invoice entity)
        {
            return entity.PayDeadline < DateTime.Now;
        }
    }
}
