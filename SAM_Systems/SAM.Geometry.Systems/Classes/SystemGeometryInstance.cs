using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class SystemGeometryInstance : IJSAMObject, ISystemGeometry
    {
        private SystemGeometrySymbol systemGeometrySymbol;
        private CoordinateSystem2D coordinateSystem;

        public SystemGeometryInstance(SystemGeometryInstance systemGeometryInstance)
        {
            if(systemGeometryInstance != null)
            {
                systemGeometrySymbol = systemGeometryInstance.systemGeometrySymbol?.Clone();
                coordinateSystem = systemGeometryInstance.coordinateSystem?.Clone();
            }
        }

        public SystemGeometryInstance(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemGeometryInstance(SystemGeometrySymbol systemGeometrySymbol, Point2D location)
        {
            this.systemGeometrySymbol = systemGeometrySymbol;
            coordinateSystem = new CoordinateSystem2D(location);
        }

        public bool Move(Vector2D vector2D)
        {
            if(vector2D == null)
            {
                return false;
            }

            coordinateSystem?.Move(vector2D);
            return true;
        }

        public bool FromJObject(JObject jObject)
        {
            throw new System.NotImplementedException();
        }

        public JObject ToJObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
