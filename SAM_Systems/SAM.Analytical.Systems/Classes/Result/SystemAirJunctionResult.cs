using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidJunctionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemLiquidJunctionResult(string uniqueId, string name, string source, Dictionary<LiquidJunctionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemLiquidJunctionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemLiquidJunctionResult(SystemLiquidJunctionResult systemLiquidJunctionResult)
            : base(systemLiquidJunctionResult)
        {

        }
    }
}
