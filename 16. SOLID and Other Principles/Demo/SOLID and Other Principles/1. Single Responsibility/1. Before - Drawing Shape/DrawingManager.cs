namespace SingleResponsibilityShapesBefore
{
    using SingleResponsibilityShapesBefore.Contracts;

    public class DrawingManager : IDrawingManager
    {
        private readonly IDrawingContext drawingContext;
        private readonly IRenderer renderer;

        public DrawingManager(IDrawingContext drawingContext, IRenderer renderer)
        {
            this.drawingContext = drawingContext;
            this.renderer = renderer;
        }

        public void Draw(IShape shape)
        {
            shape.Draw(this.renderer, this.drawingContext);
        }
    }
}
