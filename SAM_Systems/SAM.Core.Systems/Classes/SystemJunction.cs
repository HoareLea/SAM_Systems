using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemJunction : SystemJunction<ISystem>
    {
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
    }

    public abstract class SystemJunction<T> : SystemComponent where T : ISystem
    { 
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
