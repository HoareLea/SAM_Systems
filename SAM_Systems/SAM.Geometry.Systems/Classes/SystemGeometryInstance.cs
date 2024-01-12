using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;
using SAM.Geometry.Spatial;

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
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("SystemGeometrySymbol"))
            {
                systemGeometrySymbol = new SystemGeometrySymbol(jObject.Value<JObject>("SystemGeometrySymbol"));
            }

            if (jObject.ContainsKey("CoordinateSystem"))
            {
                coordinateSystem = new CoordinateSystem2D(jObject.Value<JObject>("CoordinateSystem"));
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (systemGeometrySymbol != null)
            {
                result.Add("SystemGeometrySymbol", systemGeometrySymbol.ToJObject());
            }

            if (coordinateSystem != null)
            {
                result.Add("CoordinateSystem", coordinateSystem.ToJObject());
            }

            return result;
        }
    }
}
