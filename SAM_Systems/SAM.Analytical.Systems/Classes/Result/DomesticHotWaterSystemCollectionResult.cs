using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public DomesticHotWaterSystemCollectionResult(string uniqueId, string name, string source, Dictionary<DomesticHotWaterSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public DomesticHotWaterSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public DomesticHotWaterSystemCollectionResult(DomesticHotWaterSystemCollectionResult domesticHotWaterSystemCollectionResult)
            : base(domesticHotWaterSystemCollectionResult)
        {

        }
    }
}
