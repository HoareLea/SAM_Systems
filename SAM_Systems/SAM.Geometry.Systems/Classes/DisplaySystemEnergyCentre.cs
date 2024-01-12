using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemEnergyCentre : SystemEnergyCentre<DisplaySystemPlantRoom>
    {
        public DisplaySystemEnergyCentre(string name)
            : base(name)
        {

        }

        public DisplaySystemEnergyCentre(JObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemEnergyCentre(DisplaySystemEnergyCentre displaySystemEnergyCentre)
            : base(displaySystemEnergyCentre)
        {

        }
    }
}
