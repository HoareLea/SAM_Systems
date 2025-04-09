using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Systems
{
    public class SystemJunction : SystemJunction<ISystem>
    {
        public SystemJunction(Guid guid, SystemJunction systemJunction)
            : base(guid, systemJunction)
        {

        }

        public SystemJunction(SystemJunction systemJunction)
            : base(systemJunction)
        {

        }

        public SystemJunction(JObject jObject)
            : base(jObject)
        {

        }

        public SystemJunction()
            : base(typeof(SystemJunction).Name)
        {

        }

        public SystemJunction(string name)
            : base(name)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemJunction(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }

    public abstract class SystemJunction<T> : SystemComponent, ISystemJunction where T : ISystem
    {
        public SystemJunction(System.Guid guid, SystemJunction<T> systemJunction)
            : base(guid, systemJunction)
        {

        }

        public SystemJunction(SystemJunction<T> systemJunction)
            : base(systemJunction)
        {

        }

        public SystemJunction(JObject jObject)
            : base(jObject)
        {

        }

        public SystemJunction()
            : base(typeof(SystemJunction<T>).Name)
        {

        }

        public SystemJunction(string name)
            : base(name)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager
                (
                    Create.SystemConnector<T>(Direction.In, 1),
                    Create.SystemConnector<T>(Direction.Out, 1)
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
