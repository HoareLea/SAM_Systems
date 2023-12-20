using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemDamper : SystemComponent
    {
        public SystemDamper(string name)
            : base(name)
        {

        }

        public SystemDamper(SystemFan systemFan)
            : base(systemFan)
        {

        }

        public SystemDamper(JObject jObject)
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
