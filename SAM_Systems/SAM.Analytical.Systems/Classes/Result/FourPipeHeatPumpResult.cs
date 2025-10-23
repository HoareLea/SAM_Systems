using Newtonsoft.Json.Linq;
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

        public SystemFourPipeHeatPumpResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemFourPipeHeatPumpResult(SystemFourPipeHeatPumpResult systemFourPipeHeatPumpResult)
            : base(systemFourPipeHeatPumpResult)
        {

        }
    }
}