using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class HeatingSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public HeatingSystemCollectionResult(string uniqueId, string name, string source, Dictionary<HeatingSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public HeatingSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public HeatingSystemCollectionResult(HeatingSystemCollectionResult heatingSystemCollectionResult)
            : base(heatingSystemCollectionResult)
        {

        }
    }
}
