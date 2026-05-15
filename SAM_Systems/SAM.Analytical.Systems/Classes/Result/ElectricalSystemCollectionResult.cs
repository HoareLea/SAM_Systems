using System.Text.Json.Nodes;
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

        public ElectricalSystemCollectionResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public ElectricalSystemCollectionResult(ElectricalSystemCollectionResult electricalSystemCollectionResult)
            : base(electricalSystemCollectionResult)
        {

        }
    }
}
