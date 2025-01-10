using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class GFunction : IJSAMObject
    {
        private List<Point2D> point2Ds = new List<Point2D>();

        public GFunction(IEnumerable<Point2D> point2Ds)
        {
            this.point2Ds = point2Ds == null ? null : point2Ds.ToList().ConvertAll(x => x == null ? null : new Point2D(x));
        }

        public GFunction(GFunction gFunction)
            :this(gFunction?.point2Ds)
        {

        }
        public GFunction(JObject jObject)
        {
            FromJObject(jObject);
        }

        public List<Point2D> Point2Ds
        {
            get
            {
                return point2Ds?.ConvertAll(x => x == null ? null : new Point2D(x));
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Point2Ds"))
            {
                point2Ds = Core.Create.IJSAMObjects<Point2D>(jObject.Value<JArray>("Point2Ds"));
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (point2Ds != null)
            {
                result.Add("Point2Ds", Core.Create.JArray(point2Ds));
            }

            return result;
        }
    }
}
