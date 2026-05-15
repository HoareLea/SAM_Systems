using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemAirSourceDirectAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemAirSourceDirectAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<AirSourceDirectAbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemAirSourceDirectAbsorptionChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemAirSourceDirectAbsorptionChillerResult(SystemAirSourceDirectAbsorptionChillerResult systemAirSourceDirectAbsorptionChillerResult)
            : base(systemAirSourceDirectAbsorptionChillerResult)
        {

        }
    }
}
