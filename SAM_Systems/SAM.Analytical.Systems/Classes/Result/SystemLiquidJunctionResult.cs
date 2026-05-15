using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemAirJunctionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemAirJunctionResult(string uniqueId, string name, string source, Dictionary<AirJunctionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemAirJunctionResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemAirJunctionResult(SystemAirJunctionResult systemAirJunctionResult)
            : base(systemAirJunctionResult)
        {

        }
    }
}
