using Rhino.DocObjects.Tables;
using Rhino.DocObjects;

namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        public static Layer AddSystemEnergyCentreLayer(this LayerTable layerTable)
        {
            return SAM.Core.Rhino.Modify.AddLayer(layerTable, "SystemEnergyCentre_");
        }
    }
}
