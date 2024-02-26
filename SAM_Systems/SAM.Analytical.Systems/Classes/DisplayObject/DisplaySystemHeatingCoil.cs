using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public class DisplaySystemHeatingCoil : SystemHeatingCoil, IDisplayObject<SystemGeometryInstance>
    {
        private SystemGeometryInstance systemGeometryInstance;

        public DisplaySystemHeatingCoil(SystemHeatingCoil systemHeatingCoil, SystemGeometrySymbol systemGeometrySymbol, Point2D location)
            :base(systemHeatingCoil)
        {
            systemGeometryInstance = new SystemGeometryInstance(systemGeometrySymbol, location);
        }

        public DisplaySystemHeatingCoil(DisplaySystemHeatingCoil displaySystemJunction)
            : base(displaySystemJunction)
        {
            systemGeometryInstance = displaySystemJunction?.systemGeometryInstance == null ? null : new SystemGeometryInstance(displaySystemJunction?.systemGeometryInstance);
        }

        public DisplaySystemHeatingCoil(JObject jObject)
            : base(jObject)
        {

        }

        public bool Move(Vector2D vector2D)
        {
            if(systemGeometryInstance == null || vector2D == null)
            {
                return false;
            }

            return systemGeometryInstance.Move(vector2D);
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SystemGeometryInstance"))
            {
                systemGeometryInstance = new SystemGeometryInstance(jObject.Value<JObject>("SystemGeometryInstance"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
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
