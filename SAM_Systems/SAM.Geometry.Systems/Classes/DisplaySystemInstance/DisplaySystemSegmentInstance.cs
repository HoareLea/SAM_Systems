using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemSegmentInstance : DisplaySystemInstance
    {
        private Segment2D segment2D;

        public DisplaySystemSegmentInstance(PathReference pathReference, Segment2D segment2D)
            : base(pathReference)
        {
            this.segment2D = segment2D == null ? null : new Segment2D(segment2D);
        }

        public DisplaySystemSegmentInstance(DisplaySystemSegmentInstance displaySystemSegmentInstance)
            : base(displaySystemSegmentInstance)
        {
            segment2D = displaySystemSegmentInstance.segment2D == null ? null : new Segment2D(displaySystemSegmentInstance.segment2D);
        }

        public DisplaySystemSegmentInstance(JObject jObject)
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

            if (jObject.ContainsKey("Segment2D"))
            {
                segment2D = new Segment2D(jObject.Value<JObject>("Segment2D"));
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

            if (segment2D != null)
            {
                result.Add("Segment2D", segment2D.ToJObject());
            }

            return result;
        }
    }
}
