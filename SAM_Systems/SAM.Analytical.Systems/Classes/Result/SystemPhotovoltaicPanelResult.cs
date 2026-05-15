using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemPhotovoltaicPanelResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemPhotovoltaicPanelResult(string uniqueId, string name, string source, Dictionary<PhotovoltaicPanelDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemPhotovoltaicPanelResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemPhotovoltaicPanelResult(SystemPhotovoltaicPanelResult systemPhotovoltaicPanelResult)
            : base(systemPhotovoltaicPanelResult)
        {

        }
    }
}
