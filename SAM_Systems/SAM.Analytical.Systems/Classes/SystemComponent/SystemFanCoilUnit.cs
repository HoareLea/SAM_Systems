using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemFanCoilUnit : SystemComponent, ISystemSpaceComponent
    {
        public SystemFanCoilUnit(SystemFanCoilUnit systemFanCoilUnit)
            : base(systemFanCoilUnit)
        {

        }

        public SystemFanCoilUnit(JObject jObject)
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
