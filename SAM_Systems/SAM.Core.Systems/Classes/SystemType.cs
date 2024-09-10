using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Systems
{
    public class SystemType : ISystemJSAMObject
    {
        private string typeName;

        public SystemType(SystemType systemType)
        {
            typeName = systemType?.typeName;
        }

        public SystemType(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemType(ISystem system)
            : this(system?.GetType())
        {

        }

        public SystemType(Type type)
        {
            if(IsValid(type))
            {
                typeName = Core.Query.FullTypeName(type);
            }
        }

        public Type Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(typeName))
                {
                    return null;
                }

                return Core.Query.Type(typeName, true);
            }
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(typeName) && IsValid(Type);
        }

        public bool IsValid(ISystem system)
        {
            if(system == null)
            {
                return false;
            }

            return IsValid(new SystemType(system));
        }

        public bool IsValid(SystemType systemType)
        {
            if (systemType == null)
            {
                return false;
            }

            Type type = Type;
            if (type == null)
            {
                return true;
            }

            Type type_SystemType = systemType.Type;
            if (type_SystemType == null)
            {
                return false;
            }

            return type.IsAssignableFrom(type_SystemType) || type_SystemType.IsAssignableFrom(type);
        }

        public static bool IsValid(Type type)
        {
            if(type == null)
            {
                return false;
            }

            if (!typeof(ISystem).IsAssignableFrom(type))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SystemType))
            {
                return false;
            }

            return ((SystemType)obj).typeName == typeName;
        }

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("TypeName"))
            {
                typeName = jObject.Value<string>("TypeName");
            }

            return true;
        }

        public override int GetHashCode()
        {
            if (typeName == null)
            {
                return -1;
            }

            return typeName.GetHashCode();
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName((IJSAMObject)this));

            if (!string.IsNullOrWhiteSpace(typeName))
            {
                result.Add("TypeName", typeName);
            }

            return result;
        }

        public static bool operator ==(SystemType systemType_1, SystemType systemType_2)
        {
            if (ReferenceEquals(systemType_1, systemType_2))
            {
                return true;
            }

            if (ReferenceEquals(systemType_1, null) || ReferenceEquals(systemType_2, null))
            {
                return false;
            }


            return Equals(systemType_1, systemType_2);
        }

        public static bool operator !=(SystemType systemType_1, SystemType systemType_2)
        {
            return !Equals(systemType_1, systemType_2);
        }


        public static explicit operator SystemType(Type type)
        {
            if (!IsValid(type))
            {
                return null;
            }

            return new SystemType(type);
        }

        public static implicit operator Type(SystemType systemType)
        {
            if (systemType == null)
            {
                return null;
            }

            return systemType.Type;
        }
    }
}
