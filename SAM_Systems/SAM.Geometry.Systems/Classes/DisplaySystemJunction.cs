using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemJunction : SystemJunction, IDisplayObject<SystemGeometryInstance>
    {
        private SystemGeometryInstance systemGeometryInstance;

        public DisplaySystemJunction(SystemJunction systemJunction, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            :base(systemJunction)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public bool Move(Vector2D vector2D)
        {
            if(systemGeometryInstance == null || vector2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Move(vector2D);
        }
    }
}
