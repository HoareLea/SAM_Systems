using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class AbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public AbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<AbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public AbsorptionChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public AbsorptionChillerResult(AbsorptionChillerResult absorptionChillerResult)
            : base(absorptionChillerResult)
        {

        }
    }
}
