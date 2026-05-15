using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemConnectorManager : SystemConnectorManager<DisplaySystemConnector>
    {
        public DisplaySystemConnectorManager(IEnumerable<DisplaySystemConnector> displaySystemConnectors)
            : base(displaySystemConnectors)
        {
        }

        public DisplaySystemConnectorManager()
        {

        }

        public DisplaySystemConnectorManager(JsonObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemConnectorManager(DisplaySystemConnectorManager displaySystemConnectorManager)
            : base(displaySystemConnectorManager)
        {

        }
    }
}
