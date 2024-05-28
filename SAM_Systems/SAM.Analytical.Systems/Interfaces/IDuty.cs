using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface IDuty : ISystemJSAMObject
    {
        Core.ModifiableValue ModifiableValue { get; }

        double GetValue(int index);
    }
}
