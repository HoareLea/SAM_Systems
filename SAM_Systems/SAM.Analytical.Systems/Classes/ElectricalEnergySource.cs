using System.Text.Json.Nodes;
namespace SAM.Core.Systems
{
    public class ElectricalEnergySource :SystemEnergySource
    {
        public ElectricalEnergySource(ElectricalEnergySource electricalEnergySource)
            : base(electricalEnergySource)
        {

        }

        public ElectricalEnergySource(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }
    }
}
