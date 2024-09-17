using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface ISetback : ISystemJSAMObject
    {
        string ScheduleName { get; }
    }
}
