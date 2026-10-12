namespace SITE.Interfaces;

public interface IShape : IMovable, IDrawable
{
    double Area { get; }
}
