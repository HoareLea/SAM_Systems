using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemExchanger : SystemComponent
    {
        public double SensibleEfficiency { get; set; }
        public double LatentEfficiency { get; set; }


        public SystemExchanger(string name)
            : base(name)
        {

        }

        public SystemExchanger(SystemExchanger systemExchanger)
            : base(systemExchanger)
        {

        }

        public SystemExchanger(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Core.Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SensibleEfficiency"))
            {
                SensibleEfficiency = jObject.Value<double>("SensibleEfficiency");
            }

            if (jObject.ContainsKey("LatentEfficiency"))
            {
                LatentEfficiency = jObject.Value<double>("LatentEfficiency");
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

            if (!double.IsNaN(LatentEfficiency))
            {
                result.Add("LatentEfficiency", LatentEfficiency);
            }

            if (!double.IsNaN(SensibleEfficiency))
            {
                result.Add("SensibleEfficiency", SensibleEfficiency);
            }

            return result;
        }
    }
}
