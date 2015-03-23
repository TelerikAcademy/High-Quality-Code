namespace Specification.BaseLogic
{
    using System;

    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> wrapped;

        public NotSpecification(ISpecification<TEntity> spec)
        {
            if (spec == null)
            {
                throw new ArgumentNullException("spec");
            }

            this.wrapped = spec;
        }

        protected ISpecification<TEntity> Wrapped
        {
            get
            {
                return this.wrapped;
            }
        }

        public bool IsSatisfiedBy(TEntity candidate)
        {
            return !this.Wrapped.IsSatisfiedBy(candidate);
        }
    }
}
