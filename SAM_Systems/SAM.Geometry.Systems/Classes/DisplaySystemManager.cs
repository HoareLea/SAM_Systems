using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemManager :IJSAMObject
    {
        private SystemGeometrySymbolManager systemGeometrySymbolManager;

        public DisplaySystemManager()
        {

        }

        public SystemGeometrySymbolManager SystemGeometrySymbolManager
        {
            get
            {
                return systemGeometrySymbolManager;
            }

            set
            {
                systemGeometrySymbolManager = value;
            }
        }

        public bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SystemGeometrySymbolManager"))
            {
                systemGeometrySymbolManager = new SystemGeometrySymbolManager(jObject.Value<JObject>("SystemGeometrySymbolManager")); 
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject jObject = new JObject();
            jObject.Add("_type", Core.Query.FullTypeName(this));

            if(systemGeometrySymbolManager != null)
            {
                jObject.Add("SystemGeometrySymbolManager", systemGeometrySymbolManager.ToJObject());
            }

            return jObject;
        }
    }
}
