using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public abstract class SystemGroup<T> : SystemComponent, ISystemGroup where T : ISystem
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

        public SystemGroup(JObject jObject)
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

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager
                (
                    Create.SystemConnector<T>(Direction.In, 1),
                    Create.SystemConnector<T>(Direction.Out, 1),
                    Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }

    }
}
