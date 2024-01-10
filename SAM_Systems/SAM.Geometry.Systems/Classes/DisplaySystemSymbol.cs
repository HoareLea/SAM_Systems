using Newtonsoft.Json.Linq;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemSymbol : Core.SAMObject, IDisplaySystemObject
    {
        private ISAMGeometry2D geometry2D;

        public DisplaySystemSymbol(DisplaySystemSymbol displaySystemSymbol)
            :base(displaySystemSymbol)
        {

        }

        public DisplaySystemSymbol(JObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemSymbol(string name, ISAMGeometry2D geometry2D)
            : base(name)
        {
            this.geometry2D = geometry2D?.Clone() as ISAMGeometry2D;
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Geometry2D"))
            {
                geometry2D = Core.Query.IJSAMObject<ISAMGeometry2D>(jObject.Value<JObject>("Geometry2D"));
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

            if(geometry2D != null)
            {
                result.Add("Geometry2D", geometry2D.ToJObject());
            }

            return result;
        }
    }
}
