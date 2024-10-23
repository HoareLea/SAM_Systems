using Newtonsoft.Json.Linq;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public class DisplayCoolingSystemGroup : CoolingSystemGroup, IDisplaySystemObject<SystemPolygon>
    {
        private SystemPolygon systemPolygon;

        public SystemPolygon SystemGeometry
        {
            get
            {
                return systemPolygon == null ? null : new SystemPolygon(systemPolygon);
            }
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                return systemPolygon?.GetBoundingBox();
            }
        }

        public DisplayCoolingSystemGroup(CoolingSystemGroup coolingSystemGroup, BoundingBox2D boundingBox2D)
            :base(coolingSystemGroup)
        {
            systemPolygon = new SystemPolygon(boundingBox2D?.GetPoints());
        }

        public DisplayCoolingSystemGroup(JObject jObject)
            : base(jObject)
        {

        }

        public DisplayCoolingSystemGroup(DisplayCoolingSystemGroup displayCoolingSystemGroup)
            : base(displayCoolingSystemGroup)
        {
            systemPolygon = displayCoolingSystemGroup?.systemPolygon == null ? null : new SystemPolygon(displayCoolingSystemGroup.systemPolygon);
        }

        public bool Move(Vector2D vector2D)
        {
            if(systemPolygon == null || vector2D == null)
            {
                return false;
            }

            return systemPolygon.Move(vector2D);
        }

        public bool Transform(ITransform2D transform2D)
        {
            if (transform2D == null)
            {
                return false;
            }
            systemPolygon = systemPolygon.GetTransformed(transform2D) as SystemPolygon;
            return true;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemPolygon"))
            {
                systemPolygon = new SystemPolygon(jObject.Value<JObject>("SystemPolygon"));
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

            if (systemPolygon != null)
            {
                result.Add("SystemPolygon", systemPolygon.ToJObject());
            }

            return result;
        }
    }
}
