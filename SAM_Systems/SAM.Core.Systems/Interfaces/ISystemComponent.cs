using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public interface ISystemComponent : ISystemJSAMObject
    {
        List<SystemConnector> SystemConnectors { get; }
    }
}
