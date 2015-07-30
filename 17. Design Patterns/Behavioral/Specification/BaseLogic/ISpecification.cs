namespace Specification.BaseLogic
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
