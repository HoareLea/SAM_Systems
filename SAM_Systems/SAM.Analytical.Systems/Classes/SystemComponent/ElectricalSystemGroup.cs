using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemGroup : SystemGroup<ElectricalSystem>
    {
        public ElectricalSystemGroup()
            : base()
        {
        }

        public ElectricalSystemGroup(string name)
            : base(name)
        {
        }

        public ElectricalSystemGroup(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public ElectricalSystemGroup(ElectricalSystemGroup electricalSystemGroup)
            : base(electricalSystemGroup)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            return result;
        }
    }
}
