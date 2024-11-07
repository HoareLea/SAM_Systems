using Newtonsoft.Json.Linq;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemAirSourceDirectAbsorptionChiller : SystemAirSourceDirectAbsorptionChiller, IDisplaySystemObject<SystemGeometryInstance>
    {
        private SystemGeometryInstance systemGeometryInstance;

        public SystemGeometryInstance SystemGeometry
        {
            get
            {
                return systemGeometryInstance == null ? null : new SystemGeometryInstance(systemGeometryInstance);
            }
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                return systemGeometryInstance?.BoundingBox2D;
            }
        }

        public DisplaySystemAirSourceDirectAbsorptionChiller(SystemAirSourceDirectAbsorptionChiller systemAirSourceDirectAbsorptionChiller, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            : base(systemAirSourceDirectAbsorptionChiller)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplaySystemAirSourceDirectAbsorptionChiller(DisplaySystemAirSourceDirectAbsorptionChiller displaySystemAirSourceDirectAbsorptionChiller)
            : base(displaySystemAirSourceDirectAbsorptionChiller)
        {
            systemGeometryInstance = displaySystemAirSourceDirectAbsorptionChiller?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemAirSourceDirectAbsorptionChiller?.systemGeometryInstance);
        }

        public DisplaySystemAirSourceDirectAbsorptionChiller(JObject jObject)
            : base(jObject)
        {

        }

        public bool Move(Vector2D vector2D)
        {
            if (systemGeometryInstance == null || vector2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Move(vector2D);
        }

        public bool Transform(ITransform2D transform2D)
        {
            if (systemGeometryInstance == null || transform2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Transform(transform2D);
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemGeometryInstance"))
            {
                systemGeometryInstance = new SystemGeometryInstance(jObject.Value<JObject>("SystemGeometryInstance"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            if (systemGeometryInstance != null)
            {
                result.Add("SystemGeometryInstance", systemGeometryInstance.ToJObject());
            }

            return result;
        }
    }
}
