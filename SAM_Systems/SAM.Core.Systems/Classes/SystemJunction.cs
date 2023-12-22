using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemJunction : SystemComponent
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

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Create.SystemConnectorManager
                (
                    Create.SystemConnector<ISystem>(Direction.In, 1),
                    Create.SystemConnector<ISystem>(Direction.Out, 1)
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
