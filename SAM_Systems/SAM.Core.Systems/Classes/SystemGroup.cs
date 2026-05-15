using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public abstract class SystemGroup<T> : SystemObject, ISystemGroup where T : ISystem
    {
        public SystemGroup()
            : base(string.Empty)
        {

        }

        public SystemGroup(string name)
            : base(name)
        {

        }

        public SystemGroup(SystemGroup<T> systemGroup)
            : base(systemGroup)
        {

        }

        public SystemGroup(System.Guid guid, SystemGroup<T> systemGroup)
            : base(guid, systemGroup)
        {

        }

        public SystemGroup(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemType SystemType
        {
            get
            {
                return new SystemType(typeof(T));
            }
        }

        public virtual bool IsValid(ISystemComponent systemComponent)
        {
            if(systemComponent == null)
            {
                return false;
            }

            SystemConnectorManager systemConnectorManager = systemComponent.SystemConnectorManager;
            if(systemConnectorManager == null)
            {
                return false;
            }

            List<int> indexes = systemConnectorManager.GetIndexes(SystemType);
            
            return indexes != null && indexes.Count != 0;
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }

    }
}
