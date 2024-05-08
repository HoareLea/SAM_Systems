using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface IDuty : ISystemJSAMObject
    {
        double Value { get; }
    }
}
