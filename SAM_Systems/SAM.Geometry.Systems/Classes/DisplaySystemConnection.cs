using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemConnection : SystemConnection, IDisplaySystemObject<SystemPolyline>
    {
        private SystemPolyline systemPolyline;

        public SystemPolyline SystemGeometry
        {
            get
            {
                return systemPolyline == null ? null : new SystemPolyline(systemPolyline);
            }
        }

        public BoundingBox2D BoundingBox2D
        {
            get
            {
                return systemPolyline?.GetBoundingBox();
            }
        }

        public DisplaySystemConnection(SystemConnection systemConnection, params Point2D[] point2Ds)
            :base(systemConnection)
        {
            systemPolyline = new SystemPolyline(new Polyline2D(point2Ds));
        }

        public DisplaySystemConnection(JObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemConnection(DisplaySystemConnection displaySystemConnection)
            : base(displaySystemConnection)
        {
            systemPolyline = displaySystemConnection?.systemPolyline == null ? null : new SystemPolyline(displaySystemConnection.systemPolyline);
        }

        public bool Move(Vector2D vector2D)
        {
            if(systemPolyline == null || vector2D == null)
            {
                return false;
            }

            return systemPolyline.Move(vector2D);
        }

        public bool Transform(ITransform2D transform2D)
        {
            if (transform2D == null)
            {
                return false;
            }
            systemPolyline = systemPolyline.GetTransformed(transform2D) as SystemPolyline;
            return true;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemPolyline"))
            {
                systemPolyline = new SystemPolyline(jObject.Value<JObject>("SystemPolyline"));
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

            if (systemPolyline != null)
            {
                result.Add("SystemPolyline", systemPolyline.ToJObject());
            }

            return result;
        }
    }
}
