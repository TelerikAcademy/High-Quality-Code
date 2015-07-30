namespace LiskovSubstitutionMovementAfter
{
    using System;

    using LiskovSubstitutionMovementAfter.Contracts;

    public abstract class RotatableObject : IRotatable
    {
        public abstract void Rotate();

        public virtual void Move()
        {
            this.Rotate();
        }
    }
}
