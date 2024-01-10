using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemComponent : SystemObject, ISystemComponent
    {
        public SystemComponent(SystemComponent systemComponent)
            : base(systemComponent)
        {

        }

        public SystemComponent(JObject jObject)
            : base(jObject)
        {

        }

        public SystemComponent(string name)
            : base(name)
        {

        }

        public SystemComponent(System.Guid guid, string name)
            : base(guid, name)
        {

        }

        public abstract SystemConnectorManager SystemConnectorManager { get; }

        public override bool FromJObject(JObject jObject)
        {
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }

        public virtual List<SystemConnector> GetSystemConnectors(SystemPlantRoom systemPlantRoom, ConnectorStatus connectorStatus)
        {
            if(systemPlantRoom == null)
            {
                return null;
            }

            SystemConnectorManager systemConnectionManager = SystemConnectorManager;
            if(systemConnectionManager == null)
            {
                return null;
            }

            if(connectorStatus == ConnectorStatus.Undefined)
            {
                return systemConnectionManager.SystemConnectors?.ToList();
            }

            List<int> indexes = null;

            switch(connectorStatus)
            {
                case ConnectorStatus.Undefined:
                    return systemConnectionManager.SystemConnectors?.ToList();

                case ConnectorStatus.Connected:
                    indexes = new List<int>();
                    break;

                case ConnectorStatus.Unconnected:
                    indexes = systemConnectionManager.Indexes?.ToList();
                    if (indexes == null || indexes.Count == 0)
                    {
                        return null;
                    }
                    break;
            }
            
            List<ISystemConnection> systemConnections = systemPlantRoom.GetRelatedObjects<ISystemConnection>(this);
            if(systemConnections == null || systemConnections.Count == 0)
            {
                return systemConnectionManager.SystemConnectors?.ToList();
            }

            foreach (ISystemConnection systemConnection in systemConnections)
            {
                if(systemConnection == null)
                {
                    continue;
                }

                if(!systemConnection.TryGetIndex(this, out int index))
                {
                    continue;
                }

                switch(connectorStatus)
                {
                    case ConnectorStatus.Connected:
                        indexes.Add(index);
                        break;

                    case ConnectorStatus.Unconnected:
                        indexes.Remove(index);
                        if(indexes.Count == 0)
                        {
                            return new List<SystemConnector>();
                        }
                        break;
                }

            }

            return systemConnectionManager.GetSystemConnectors(indexes);
        }
    }
}
