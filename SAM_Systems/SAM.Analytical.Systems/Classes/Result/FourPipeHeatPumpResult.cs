using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemFourPipeHeatPumpResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemFourPipeHeatPumpResult(string uniqueId, string name, string source, Dictionary<FourPipeHeatPumpDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemFourPipeHeatPumpResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemFourPipeHeatPumpResult(SystemFourPipeHeatPumpResult systemFourPipeHeatPumpResult)
            : base(systemFourPipeHeatPumpResult)
        {

        }
    }
}