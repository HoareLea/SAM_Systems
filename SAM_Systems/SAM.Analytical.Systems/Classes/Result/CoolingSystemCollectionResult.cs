using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class CoolingSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public CoolingSystemCollectionResult(string uniqueId, string name, string source, Dictionary<CoolingSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public CoolingSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public CoolingSystemCollectionResult(CoolingSystemCollectionResult coolingSystemCollectionResult)
            : base(coolingSystemCollectionResult)
        {

        }
    }
}
