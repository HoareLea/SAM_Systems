using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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

        public override List<SystemConnector> SystemConnectors
        {
            get
            {
                return new List<SystemConnector>()
                {
                    Create.SystemConnector<ISystem>(Direction.In),
                    Create.SystemConnector<ISystem>(Direction.Out)
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
