
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public interface IDisplaySystemObject<T> : IDisplaySystemObject where T : ISystemGeometry
    {
        T SystemGeometry { get; }
    }

    public interface IDisplaySystemObject
    {
        BoundingBox2D BoundingBox2D { get; }

        bool Move(Vector2D vector2D);

        bool Transform(ITransform2D transform2D);
    }
}
