namespace Specification.BaseLogic
{
    public static class ExtensionMethods
    {
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new AndSpecification<TEntity>(spec1, spec2);
        }

        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
        {
            return new OrSpecification<TEntity>(spec1, spec2);
        }

        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> spec)
        {
            return new NotSpecification<TEntity>(spec);
        }
    }
}
