using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSolarPanelResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSolarPanelResult(string uniqueId, string name, string source, Dictionary<SolarPanelDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSolarPanelResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemSolarPanelResult(SystemSolarPanelResult systemPumpResult)
            : base(systemPumpResult)
        {

        }
    }
}
