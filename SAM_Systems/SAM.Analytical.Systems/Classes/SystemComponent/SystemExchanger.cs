using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemExchanger : SystemComponent
    {
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

        public override List<SystemConnector> SystemConnectors
        {
            get
            {
                return new List<SystemConnector>()
                {
                    Create.SystemConnector<AirSystem>(Core.Direction.In),
                    Create.SystemConnector<AirSystem>(Core.Direction.Out),
                    Create.SystemConnector<AirSystem>(Core.Direction.In),
                    Create.SystemConnector<AirSystem>(Core.Direction.Out),
                    Create.SystemConnector<IControlSystem>(),
                };
            }
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
