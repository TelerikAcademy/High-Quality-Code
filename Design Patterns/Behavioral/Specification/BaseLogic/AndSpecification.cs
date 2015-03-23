namespace Specification.BaseLogic
{
    using System;

    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> specification1;
        private readonly ISpecification<TEntity> specification2;

        public AndSpecification(ISpecification<TEntity> specification1, ISpecification<TEntity> specification2)
        {
            if (specification1 == null)
            {
                throw new ArgumentNullException("specification1");
            }

            if (specification2 == null)
            {
                throw new ArgumentNullException("specification2");
            }

            this.specification1 = specification1;
            this.specification2 = specification2;
        }

        protected ISpecification<TEntity> Specification1
        {
            get
            {
                return this.specification1;
            }
        }

        protected ISpecification<TEntity> Specification2
        {
            get
            {
                return this.specification2;
            }
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return this.Specification1.IsSatisfiedBy(candidate) && this.Specification2.IsSatisfiedBy(candidate);
        }
    }
}
