using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemEconomiser : SystemComponent
    {
        public ModifiableValue Setpoint { get; set; }

        public SystemEconomiser(string name)
            : base(name)
        {

        }

        public SystemEconomiser(SystemEconomiser systemEconomiser)
            : base(systemEconomiser)
        {
            if(systemEconomiser != null)
            {
                Setpoint = systemEconomiser.Setpoint.Clone();   
            }
        }

        public SystemEconomiser(JObject jObject)
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

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            return result;
        }
    }
}
