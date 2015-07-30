namespace LiskovSubstitutionMovementBefore
{
    using System;

    public class RotatableObject : MovableObject
    {
        public override void Translate()
        {
            throw new NotImplementedException();
        }

        public override void Rotate()
        {
            // do rotation logic
        }

        public override void Move()
        {
            this.Rotate();
        }
    }
}
