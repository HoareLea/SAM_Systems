using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Horizontal GHE, Heat Rejection (Liquid Side)
    /// </summary>
    public class SystemHorizontalExchanger : SystemComponent
    {
        public SystemHorizontalExchanger(string name)
            : base(name)
        {

        }

        public SystemHorizontalExchanger(SystemHorizontalExchanger systemHorizontalExchanger)
            : base(systemHorizontalExchanger)
        {

        }

        public SystemHorizontalExchanger(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
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