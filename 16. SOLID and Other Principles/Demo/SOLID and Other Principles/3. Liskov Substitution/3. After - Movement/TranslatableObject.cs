namespace LiskovSubstitutionMovementAfter
{
    using LiskovSubstitutionMovementAfter.Contracts;

    public abstract class TranslatableObject : ITranslatable
    {
        public abstract void Translate();

        public virtual void Move()
        {
            this.Translate();
        }
    }
}
