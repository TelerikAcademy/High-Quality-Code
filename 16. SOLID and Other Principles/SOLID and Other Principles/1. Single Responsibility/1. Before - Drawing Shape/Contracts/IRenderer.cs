namespace SingleResponsibilityShapesBefore.Contracts
{
    public interface IRenderer
    {
        void Render(IDrawingContext context, IShape shape);
    }
}
