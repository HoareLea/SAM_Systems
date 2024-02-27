using Newtonsoft.Json.Linq;
using SAM.Core;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemConnectorManager : IJSAMObject
    {
        private List<DisplaySystemConnector> displaySystemConnectors;

        public DisplaySystemConnectorManager(IEnumerable<DisplaySystemConnector> displaySystemConnectors)
        {
            this.displaySystemConnectors = displaySystemConnectors == null ? null : displaySystemConnectors.ToList().ConvertAll(x => new DisplaySystemConnector(x));
        }

        public DisplaySystemConnectorManager(JObject jObject)
        {
            FromJObject(jObject);
        }

        public DisplaySystemConnectorManager(DisplaySystemConnectorManager displaySystemConnectorManager)
        {
            if(displaySystemConnectorManager != null)
            {
                displaySystemConnectors = displaySystemConnectorManager.displaySystemConnectors == null ? null : displaySystemConnectorManager.displaySystemConnectors.ToList().ConvertAll(x => new DisplaySystemConnector(x));
            }
        }

        public List<DisplaySystemConnector> DisplaySystemConnectors
        {
            get
            {
                return displaySystemConnectors == null ? null : displaySystemConnectors.ConvertAll(x => new DisplaySystemConnector(x));
            }
        }

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }
            
            if (jObject.ContainsKey("DisplaySystemConnectors"))
            {
                JArray jArray = jObject.Value<JArray>("DisplaySystemConnectors");
                if (jArray != null)
                {
                    displaySystemConnectors = new List<DisplaySystemConnector>();
                    foreach (JObject jObject_DisplaySystemConnector in jArray)
                    {
                        displaySystemConnectors.Add(new DisplaySystemConnector(jObject_DisplaySystemConnector));
                    }
                }
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (displaySystemConnectors != null)
            {
                JArray jArray = new JArray();
                foreach (DisplaySystemConnector displaySystemConnector in displaySystemConnectors)
                {
                    jArray.Add(displaySystemConnector.ToJObject());
                }

                result.Add("DisplaySystemConnectors", jArray);
            }

            return result;
        }
    }
}
