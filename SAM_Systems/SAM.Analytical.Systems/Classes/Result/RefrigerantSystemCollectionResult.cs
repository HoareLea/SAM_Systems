using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystemCollectionResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public RefrigerantSystemCollectionResult(string uniqueId, string name, string source, Dictionary<RefrigerantSystemCollectionDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public RefrigerantSystemCollectionResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public RefrigerantSystemCollectionResult(RefrigerantSystemCollectionResult refrigerantSystemCollectionResult)
            : base(refrigerantSystemCollectionResult)
        {

        }
    }
}
