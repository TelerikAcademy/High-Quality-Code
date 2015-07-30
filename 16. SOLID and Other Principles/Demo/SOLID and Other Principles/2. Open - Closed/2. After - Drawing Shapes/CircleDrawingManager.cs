namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;

    public class CircleDrawingManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Circle;
            
            // Draw rectangle
        }
    }
}