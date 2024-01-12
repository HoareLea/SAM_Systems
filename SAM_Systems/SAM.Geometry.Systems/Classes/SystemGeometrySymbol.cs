using SAM.Geometry.Object.Planar;
using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Geometry.Systems
{
    public class SystemGeometrySymbol : SAMObject, ISAMGeometry2DObject
    {
        private ISAMGeometry2DObject geometry;

        public SystemGeometrySymbol(string name, ISAMGeometry2DObject geometry)
            : base(name)
        {
            this.geometry = geometry?.Clone();
        }

        public SystemGeometrySymbol(ISAMGeometry2DObject geometry)
            :base()
        {
            this.geometry = geometry?.Clone();
        }

        public SystemGeometrySymbol(JObject jObject)
            :base(jObject)
        {

        }

        public SystemGeometrySymbol(SystemGeometrySymbol systemGeometrySymbol)
            :base(systemGeometrySymbol)
        {
            geometry = systemGeometrySymbol?.Geometry;
        }

        public ISAMGeometry2DObject Geometry
        {
            get
            {
                return geometry?.Clone();
            }
        }

        public bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Geometry"))
            {
                geometry = Core.Query.IJSAMObject<ISAMGeometry2DObject>(jObject.Value<JObject>("Geometry"));
            }

            return result;
        }

        public JObject ToJObject()
        {
            JObject result = base.ToJObject();

            if(geometry != null)
            {
                result.Add("Geometry", geometry.ToJObject());
            }

            return result;
        }
    }
}
