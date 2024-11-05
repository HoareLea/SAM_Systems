using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemPhotovoltaicPanelResult : SystemIndexedDoublesResult, ISystemComponentResult
    { 
        public SystemPhotovoltaicPanelResult(string uniqueId, string name, string source, Dictionary<PhotovoltaicPanelDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemPhotovoltaicPanelResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemPhotovoltaicPanelResult(SystemPhotovoltaicPanelResult systemPhotovoltaicPanelResult)
            : base(systemPhotovoltaicPanelResult)
        {

        }
    }
}
