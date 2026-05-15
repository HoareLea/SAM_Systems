using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemHeatPump : SystemComponent, ILiquidSystemComponent
    {
        public SystemHeatPump(string name)
            : base(name)
        {

        }

        public SystemHeatPump(SystemHeatPump systemHeatPump)
            : base(systemHeatPump)
        {

        }  
        
        public SystemHeatPump(System.Guid guid, SystemHeatPump systemHeatPump)
            : base(guid, systemHeatPump)
        {

        }

        public SystemHeatPump(JsonObject jObject)
            : base(jObject)
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

