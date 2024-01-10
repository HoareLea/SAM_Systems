using System.Linq;

namespace SAM.Core.Systems
{
    public static partial class Create
    {
        public static SystemConnectorManager SystemConnectorManager(params SystemConnector[] systemConnectors) 
        {
            return new SystemConnectorManager(systemConnectors?.ToList());
        }
    }
}