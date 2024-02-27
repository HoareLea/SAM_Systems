using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoil : SystemComponent
    {
        public SystemDXCoil(string name)
            : base(name)
        {

        }

        public SystemDXCoil(SystemDXCoil systemDXCoil)
            : base(systemDXCoil)
        {

        }

        public SystemDXCoil(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<IControlSystem>()

                );
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
