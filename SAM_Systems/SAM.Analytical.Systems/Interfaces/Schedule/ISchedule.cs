using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface ISchedule : ISystemJSAMObject
    {
        string Name { get; }
        string Description { get; set; }
    }
}
