using System.Text.Json.Nodes;
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

        public SystemObject(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject["Description"]?.GetValue<string>() ?? null;
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
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

        public abstract SystemObject Duplicate(Guid? guid = null);

        public T Duplicate<T>(Guid? guid = null) where T : SystemObject
        {
            return Duplicate(guid) as T;
        }
    }
}
