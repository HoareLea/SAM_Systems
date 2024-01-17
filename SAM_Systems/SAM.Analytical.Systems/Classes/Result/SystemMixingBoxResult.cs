using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemMixingBoxResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemMixingBoxResult(string uniqueId, string name, string source, Dictionary<MixingBoxDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemMixingBoxResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemMixingBoxResult(SystemMixingBoxResult systemMixingBoxResult)
            : base(systemMixingBoxResult)
        {

        }
    }
}
