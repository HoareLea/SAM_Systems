using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemFan : SystemComponent
    {
        public SystemFan(string name)
            : base(name)
        {

        }

        public SystemFan(SystemFan systemFan)
            : base(systemFan)
        {

        }

        public SystemFan(JObject jObject)
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
                    Create.SystemConnector<ElectricalSystem>(),
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
