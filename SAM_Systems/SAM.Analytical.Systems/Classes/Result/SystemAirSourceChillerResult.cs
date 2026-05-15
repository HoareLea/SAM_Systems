using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemAirSourceChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemAirSourceChillerResult(string uniqueId, string name, string source, Dictionary<AirSourceChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemAirSourceChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemAirSourceChillerResult(SystemAirSourceChillerResult systemAirSourceChillerResult)
            : base(systemAirSourceChillerResult)
        {

        }
    }
}
