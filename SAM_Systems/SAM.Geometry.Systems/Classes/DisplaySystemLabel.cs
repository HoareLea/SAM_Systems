using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemLabel : SystemLabel, IJSAMObject
    {
        private Point2D location;

        public DisplaySystemLabel(SystemLabel systemLabel, Point2D location, LabelDirection labelDirection, int height)
            : base(systemLabel)
        {
            this.location = location == null ? null : new Point2D(location);
            this.labelDirection = labelDirection;
            this.height = height;

        }

        public DisplaySystemLabel(DisplaySystemLabel displaySystemLabel)
            : base(displaySystemLabel)
        {
            if (displaySystemLabel != null)
            {
                location = displaySystemLabel.Location == null ? null : new Point2D(displaySystemLabel.Location);
                labelDirection = displaySystemLabel.labelDirection;
                height = displaySystemLabel.height;
            }
        }

        public DisplaySystemLabel(JObject jObject)
            : base(jObject)
        {

        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public LabelDirection LabelDirection
        {
            get
            {
                return labelDirection;
            }
        }

        public Point2D Location
        {
            get
            {
                return location;
            }
        }

        private int height { get; set; }
        
        private LabelDirection labelDirection { get; set; }
        
        public bool FromJObject(JObject jObject)
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

            if (jObject.ContainsKey("LabelDirection"))
            {
                labelDirection = Core.Query.Enum<LabelDirection>(jObject.Value<string>("LabelDirection"));
            }

            if (jObject.ContainsKey("Height"))
            {
                height = jObject.Value<int>("Height");
            }

            return result;
        }
        
        public JObject ToJObject()
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

            result.Add("Height", height);

            result.Add("LabelDirection", labelDirection.ToString());

            return result;
        }
    }
}
