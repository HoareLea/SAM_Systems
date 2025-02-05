using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class ElectricalEnergySource :SystemEnergySource
    {
        public ElectricalEnergySource(ElectricalEnergySource electricalEnergySource)
            : base(electricalEnergySource)
        {

        }

        public ElectricalEnergySource(JObject jObject)
            : base(jObject)
        {

        }

        public ElectricalEnergySource(string name)
            : base(name)
        {

        }

        public ElectricalEnergySource(System.Guid guid, string name)
            : base(guid, name)
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
