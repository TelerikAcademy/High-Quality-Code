namespace SingleResponsibilityShapesBefore.Contracts
{
    public interface IShape
    {
        void Draw(IRenderer render, IDrawingContext context);
    }
}
