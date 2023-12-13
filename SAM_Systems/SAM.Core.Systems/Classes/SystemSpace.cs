using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemSpace : SystemObject, ISystemSpatialObject
    {
        public SystemSpace(SystemSpace systemSpace)
            : base(systemSpace)
        {

        }

        public SystemSpace(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
