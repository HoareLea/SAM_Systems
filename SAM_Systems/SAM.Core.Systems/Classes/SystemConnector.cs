using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemConnector: ISystemJSAMObject
    {
        private Direction direction = Direction.Undefined;
        private SystemType systemType;

        public SystemConnector(ISystem system)
            : this(new SystemType(system), Direction.Undefined)
        {

        }

        public SystemConnector(ISystem system, Direction direction)
            : this(new SystemType(system), direction)
        {

        }
        
        public SystemConnector(SystemType systemType, Direction direction)
        {
            this.direction = direction;
            this.systemType = systemType;
        }

        public SystemConnector(SystemType systemType)
        {
            direction = Direction.Undefined;
            this.systemType = systemType;
        }

        public SystemConnector(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemConnector(SystemConnector systemConnector)
        {
            if (systemConnector != null)
            {
                direction = systemConnector.direction;
                systemType = systemConnector.systemType == null ? null : new SystemType(systemConnector.systemType);
            }
        }

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemType"))
            {
                systemType = new SystemType(jObject.Value<JObject>("SystemType"));
            }

            if (jObject.ContainsKey("Direction"))
            {
                direction = Core.Query.Enum<Direction>(jObject.Value<string>("Direction"));
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(systemType != null)
            {
                result.Add("SystemType", systemType.ToJObject());
            }

            result.Add("Direction", direction.ToString());

            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = -1;
            if(systemType != null)
            {
                hashCode = systemType.GetHashCode();
            }

            return new { hashCode, direction }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is SystemConnector))
            {
                return false;
            }

            SystemConnector systemConnector = (SystemConnector)obj;

            return systemConnector.direction.Equals(direction) && systemConnector?.systemType == systemType;
        }

        public static bool operator ==(SystemConnector systemConnector_1, SystemConnector systemConnector_2)
        {
            if (ReferenceEquals(systemConnector_1, systemConnector_2))
            {
                return true;
            }

            if (ReferenceEquals(systemConnector_1, null) || ReferenceEquals(systemConnector_2, null)) 
            {
                return false;
            }


            return Equals(systemConnector_1, systemConnector_2);
        }

        public static bool operator !=(SystemConnector systemConnector_1, SystemConnector systemConnector_2)
        {
            return !Equals(systemConnector_1, systemConnector_2);
        }
    }
}
