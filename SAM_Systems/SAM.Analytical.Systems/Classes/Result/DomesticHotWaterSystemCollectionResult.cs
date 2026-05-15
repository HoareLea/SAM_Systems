using System.Text.Json.Nodes;
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

        public DomesticHotWaterSystemCollectionResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public DomesticHotWaterSystemCollectionResult(DomesticHotWaterSystemCollectionResult domesticHotWaterSystemCollectionResult)
            : base(domesticHotWaterSystemCollectionResult)
        {

        }
    }
}
