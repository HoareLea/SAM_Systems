using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemBoiler: SystemComponent
    {
        public SystemBoiler(SystemBoiler systemBoiler)
            : base(systemBoiler)
        {

        }

        public SystemBoiler(JObject jObject)
            : base(jObject)
        {

        }

        public override List<SystemConnector> SystemConnectors
        {
            get
            {
                return new List<SystemConnector>()
                {
                    Create.SystemConnector<LiquidSystem>(Core.Direction.In),
                    Create.SystemConnector<LiquidSystem>(Core.Direction.Out),
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
