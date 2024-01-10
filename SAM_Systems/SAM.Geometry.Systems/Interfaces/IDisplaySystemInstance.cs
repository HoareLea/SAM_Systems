using SAM.Core;

namespace SAM.Geometry.Systems
{
    public interface IDisplaySystemInstance : IDisplaySystemObject
    {
        PathReference PathReference { get; }
    }
}
