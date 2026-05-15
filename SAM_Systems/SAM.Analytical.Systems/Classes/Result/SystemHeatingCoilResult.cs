using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemHeatingCoilResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemHeatingCoilResult(string uniqueId, string name, string source, Dictionary<HeatingCoilDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemHeatingCoilResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemHeatingCoilResult(SystemHeatingCoilResult systemHeatingCoilResult)
            : base(systemHeatingCoilResult)
        {

        }
    }
}
