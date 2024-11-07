using Newtonsoft.Json.Linq;
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

        public SystemAbsorptionChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemAbsorptionChillerResult(SystemAbsorptionChillerResult systemAbsorptionChillerResult)
            : base(systemAbsorptionChillerResult)
        {

        }
    }
}
