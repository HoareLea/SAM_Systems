using Newtonsoft.Json.Linq;
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

        public SystemHeatingCoilResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemHeatingCoilResult(SystemHeatingCoilResult systemHeatingCoilResult)
            : base(systemHeatingCoilResult)
        {

        }
    }
}
