using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class AirSourceDirectAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public AirSourceDirectAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<AirSourceDirectAbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public AirSourceDirectAbsorptionChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public AirSourceDirectAbsorptionChillerResult(AirSourceDirectAbsorptionChillerResult airSourceDirectAbsorptionChillerResult)
            : base(airSourceDirectAbsorptionChillerResult)
        {

        }
    }
}
