using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface ISizableValue : ISystemJSAMObject
    {
        SizingType SizingType { get; }
    }
}
