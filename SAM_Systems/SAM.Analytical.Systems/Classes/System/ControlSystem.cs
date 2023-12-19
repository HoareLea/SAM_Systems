using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class ControlSystem : SystemObject, IControlSystem
    {
        public ControlSystem(ControlSystem controlSystem)
            : base(controlSystem)
        {
        }

        public ControlSystem(JObject jObject)
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
