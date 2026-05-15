using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemEnergyCentre : SystemEnergyCentre<DisplaySystemPlantRoom>
    {
        public DisplaySystemEnergyCentre(string name)
            : base(name)
        {

        }

        public DisplaySystemEnergyCentre(JsonObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemEnergyCentre(DisplaySystemEnergyCentre displaySystemEnergyCentre)
            : base(displaySystemEnergyCentre)
        {

        }
    }
}
