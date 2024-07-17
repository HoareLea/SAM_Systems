using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Systems
{
    public abstract class SystemObject : SAMObject, ISystemObject, ISystemJSAMObject
    {
        public new string Name
        {
            set
            {
                name = value;
            }

            get
            {
                return name;
            }
        }

        public string Description { get; set; }

        public SystemObject(SystemObject systemObject)
            : base(systemObject)
        {
            Description = systemObject?.Description;
        }

        public SystemObject(Guid guid, SystemObject systemObject)
            : base(guid, systemObject)
        {
            Description = systemObject?.Description;
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
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject.Value<string>("Description");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            if (Description != null)
            {
                result.Add("Description", Description);
            }

            return result;
        }
    }
}
