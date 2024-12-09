using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public ElectricalSystemCollectionResult(string uniqueId, string name, string source, Dictionary<ElectricalSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public ElectricalSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public ElectricalSystemCollectionResult(ElectricalSystemCollectionResult electricalSystemCollectionResult)
            : base(electricalSystemCollectionResult)
        {

        }
    }
}
