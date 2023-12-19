using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemRectangleInstance : DisplaySystemInstance
    {
        private Rectangle2D rectangle2D;

        public DisplaySystemRectangleInstance(PathReference pathReference, Rectangle2D rectangle2D)
            :base(pathReference)
        {
            this.rectangle2D = rectangle2D == null ? null : new Rectangle2D(rectangle2D);
        }

        public DisplaySystemRectangleInstance(DisplaySystemRectangleInstance displaySystemRectangleInstance )
            : base(displaySystemRectangleInstance)
        {
            rectangle2D = displaySystemRectangleInstance.rectangle2D == null ? null : new Rectangle2D(displaySystemRectangleInstance.rectangle2D);
        }

        public DisplaySystemRectangleInstance(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Rectangle2D"))
            {
                rectangle2D = new Rectangle2D(jObject.Value<JObject>("Rectangle2D"));
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

            if(rectangle2D != null)
            {
                result.Add("Rectangle2D", rectangle2D.ToJObject());
            }

            return result;
        }

    }
}
