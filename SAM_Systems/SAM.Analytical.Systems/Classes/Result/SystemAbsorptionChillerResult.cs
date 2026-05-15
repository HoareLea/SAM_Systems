using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<AbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemAbsorptionChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemAbsorptionChillerResult(SystemAbsorptionChillerResult systemAbsorptionChillerResult)
            : base(systemAbsorptionChillerResult)
        {

        }
    }
}
