namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;

    public abstract class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            this.DrawFigure(shape);
        }

        protected abstract void DrawFigure(IShape shape);
    }
}
