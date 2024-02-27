using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemConnector : SystemConnector
    {
        private Point2D location;

        public DisplaySystemConnector(SystemConnector systemConnector, Point2D location)
            :base(systemConnector)
        {
            this.location = location == null ? null : new Point2D(location);
        }

        public DisplaySystemConnector(DisplaySystemConnector displaySystemConnector)
            :base(displaySystemConnector)
        {
            if(displaySystemConnector != null)
            {
                location = displaySystemConnector.Location == null ? null : new Point2D(displaySystemConnector.Location);
            }
        }

        public DisplaySystemConnector(JObject jObject)
            :base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Location"))
            {
                location = new Point2D(jObject.Value<JObject>("Location"));
            }

            return result;
        }

        public Point2D Location
        {
            get
            {
                return location;
            }
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return null;
            }

            if(Location != null)
            {
                result.Add("Location", location.ToJObject());
            }

            return result;
        }
    }
}
