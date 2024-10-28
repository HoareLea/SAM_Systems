using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceAbsorptionChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemWaterSourceAbsorptionChillerResult(string uniqueId, string name, string source, Dictionary<WaterSourceAbsorptionChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemWaterSourceAbsorptionChillerResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemWaterSourceAbsorptionChillerResult(SystemWaterSourceAbsorptionChillerResult systemWaterSourceAbsorptionChillerResult)
            : base(systemWaterSourceAbsorptionChillerResult)
        {

        }
    }
}
