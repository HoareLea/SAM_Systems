using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public interface ISystemConnection : ISystemComponent
    {
        SystemType SystemType { get; }

        bool TryGetIndex(ISystemComponent systemComponent, out int index);

        bool TryGetIndex(ObjectReference objectReference, out int index);

        List<ObjectReference> ObjectReferences { get; }
    }
}
