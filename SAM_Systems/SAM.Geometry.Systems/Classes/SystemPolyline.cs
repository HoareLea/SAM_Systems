using SAM.Geometry.Object.Planar;
using Newtonsoft.Json.Linq;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class SystemPolyline : Polyline2DObject, ISystemGeometry
    {
        public SystemPolyline(Polyline2D polyline2D) 
            : base(polyline2D)
        {
        }

        public SystemPolyline(JObject jObject)
            : base(jObject)
        {
        }

        public SystemPolyline(SystemPolyline systemPolyline)
            : base(systemPolyline)
        {
        }

        public ISAMGeometry2DObject GetGeometry()
        {
            return new Polyline2DObject(this);
        }
    }
}
