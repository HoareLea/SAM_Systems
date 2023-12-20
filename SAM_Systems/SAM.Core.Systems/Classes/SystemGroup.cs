using Newtonsoft.Json.Linq;
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

            List<SystemConnector> systemConnectors= systemComponent.SystemConnectors;
            if(systemConnectors == null || systemConnectors.Count == 0)
            {
                return false;
            }

            SystemType systemType = SystemType;
            if(systemType == null)
            {
                return true;
            }

            return systemConnectors.FindIndex(x => x.IsValid(systemType)) != -1;
        }

        public virtual List<SystemConnector> SystemConnectors
        {
            get
            {
                return new List<SystemConnector>()
                {
                    Create.SystemConnector<T>(Direction.In),
                    Create.SystemConnector<T>(Direction.Out),
                    Create.SystemConnector<IControlSystem>()
                };
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
