using Newtonsoft.Json.Linq;

namespace SAM.Core.Systems
{
    public class SystemConnector: ISystemJSAMObject
    {
        private int connectionIndex = -1;
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
        
        public SystemConnector(ISystem system, Direction direction, int connectionIndex)
            : this(new SystemType(system), direction)
        {
            this.connectionIndex = connectionIndex;
        }

        public SystemConnector(SystemType systemType, Direction direction, int connectionIndex)
            :this(systemType, direction)
        {
            this.connectionIndex = connectionIndex;
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
                connectionIndex = systemConnector.connectionIndex;
            }
        }

        public int ConnectionIndex
        {
            get
            {
                return connectionIndex;
            }
        }
        
        public Direction Direction
        {
            get
            {
                return direction;
            }
        }

        public SystemType SystemType
        {
            get
            {
                return systemType == null ? null : new SystemType(systemType);
            }
        }

        public bool IsValid(ISystem system)
        {
            if(systemType == null)
            {
                return true;
            }

            return IsValid(new SystemType(system));
        }

        public bool IsValid(SystemType systemType)
        {
            if(systemType == null)
            {
                return false;
            }

            if (this.systemType == null)
            {
                return true;
            }

            return this.systemType.IsValid(systemType);
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

            if(jObject.ContainsKey("ConnectionIndex"))
            {
                connectionIndex = jObject.Value<int>("ConnectionIndex");
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

            result.Add("ConnectionIndex", connectionIndex);

            return result;
        }

        public override int GetHashCode()
        {
            int hashCode = -1;
            if(systemType != null)
            {
                hashCode = systemType.GetHashCode();
            }

            return new { hashCode, direction, connectionIndex }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is SystemConnector))
            {
                return false;
            }

            SystemConnector systemConnector = (SystemConnector)obj;

            return systemConnector.direction.Equals(direction) && systemConnector.systemType == systemType && systemConnector.connectionIndex == connectionIndex;
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
