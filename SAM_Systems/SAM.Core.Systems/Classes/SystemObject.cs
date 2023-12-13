using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Systems
{
    public abstract class SystemObject : SAMObject, ISystemObject
    {
        public new string Name
        {
            set
            {
                name = value;
            }
        }

        public SystemObject(SystemObject systemObject)
            : base(systemObject)
        {

        }

        public SystemObject(JObject jObject)
            : base(jObject)
        {

        }

        public SystemObject(string name)
            : base(name)
        {

        }

        public SystemObject(Guid guid, string name)
            : base(guid, name)
        {

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
