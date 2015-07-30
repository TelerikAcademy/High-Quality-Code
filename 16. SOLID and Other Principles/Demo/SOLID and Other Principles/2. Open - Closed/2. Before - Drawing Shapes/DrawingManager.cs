namespace OpenClosedDrawingShapesBefore
{
    using OpenClosedDrawingShapesBefore.Contracts;

    public class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            if (shape is Circle)
            {
                this.DrawCircle(shape as Circle);
            }
            else if (shape is Rectangle)
            {
                this.DrawRectangle(shape as Rectangle);
            }
        }

        private void DrawRectangle(Rectangle rectangle)
        {
            // Draw Rectangle
        }

        private void DrawCircle(Circle circle)
        {
            // Draw Circle
        }
    }
}
