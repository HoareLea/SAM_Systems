using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class FuelSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public FuelSystemCollectionResult(string uniqueId, string name, string source, Dictionary<FuelSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public FuelSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public FuelSystemCollectionResult(FuelSystemCollectionResult fuelSystemCollectionResult)
            : base(fuelSystemCollectionResult)
        {

        }
    }
}
