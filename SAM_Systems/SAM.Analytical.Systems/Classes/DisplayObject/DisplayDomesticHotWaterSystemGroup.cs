using Newtonsoft.Json.Linq;
using SAM.Geometry.Planar;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public class DisplayDomesticHotWaterSystemGroup : DomesticHotWaterSystemGroup, IDisplaySystemObject<SystemPolygon>
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

        public DisplayDomesticHotWaterSystemGroup(DomesticHotWaterSystemGroup domesticHotWaterSystemGroup, BoundingBox2D boundingBox2D)
            :base(domesticHotWaterSystemGroup)
        {
            systemPolygon = new SystemPolygon(boundingBox2D?.GetPoints());
        }

        public DisplayDomesticHotWaterSystemGroup(JObject jObject)
            : base(jObject)
        {

        }

        public DisplayDomesticHotWaterSystemGroup(DisplayDomesticHotWaterSystemGroup displayDomesticHotWaterSystemGroup)
            : base(displayDomesticHotWaterSystemGroup)
        {
            systemPolygon = displayDomesticHotWaterSystemGroup?.systemPolygon == null ? null : new SystemPolygon(displayDomesticHotWaterSystemGroup.systemPolygon);
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
