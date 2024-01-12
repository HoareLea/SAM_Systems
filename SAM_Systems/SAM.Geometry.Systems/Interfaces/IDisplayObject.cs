
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public interface IDisplayObject<T> : IDisplayObject where T : ISystemGeometry
    {
    }

    public interface IDisplayObject
    {
        bool Move(Vector2D vector2D);
    }
}
