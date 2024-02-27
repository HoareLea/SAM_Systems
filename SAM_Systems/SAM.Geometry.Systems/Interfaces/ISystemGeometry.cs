
using SAM.Geometry.Object.Planar;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public interface ISystemGeometry
    {
        bool Move(Vector2D vector2D);

        ISAMGeometry2DObject GetGeometry();

    }
}
