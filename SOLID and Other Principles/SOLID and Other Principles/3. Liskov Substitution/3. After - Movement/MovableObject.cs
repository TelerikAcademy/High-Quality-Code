namespace LiskovSubstitutionMovementAfter
{
    using LiskovSubstitutionMovementAfter.Contracts;

    public abstract class MovableObject : IMovable
    {
        public abstract void Translate();

        public abstract void Rotate();

        public virtual void Move()
        {
            this.Translate();
            this.Rotate();
        }
    }
}
