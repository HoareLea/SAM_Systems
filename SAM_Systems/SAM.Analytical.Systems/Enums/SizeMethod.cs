using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Size Method")]
    public enum SizeMethod
    {
        [Description("Normal")] Normal,
        [Description("Add Load All Attached")] AddLoadAllAttached,
        [Description("Add Load All Attached Heating")] AddLoadAllAttachedHeating,
        [Description("Add Load All Attached DHW")] AddLoadAllAttachedDHW,
        [Description("Add Load All Attached Chiller")] AddLoadAllAttachedChiller,
        [Description("Add Load Local")] AddLoadLocal,
        [Description("Design Flow")] DesignFlow,
        [Description("Sized")] Sized,
    }
}
