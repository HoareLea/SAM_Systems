using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSprayHumidifierResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemSprayHumidifierResult(string uniqueId, string name, string source, Dictionary<SprayHumidifierDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemSprayHumidifierResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSprayHumidifierResult(SystemSprayHumidifierResult systemSprayHumidifierResult)
            : base(systemSprayHumidifierResult)
        {

        }
    }
}
