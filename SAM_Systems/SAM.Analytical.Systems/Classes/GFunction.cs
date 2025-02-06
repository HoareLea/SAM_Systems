using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class GFunction : IJSAMObject, Core.Systems.ISystemObject
    {
        private List<Point2D> point2Ds = new List<Point2D>();

        public GFunction(IEnumerable<Point2D> point2Ds)
        {
            this.point2Ds = point2Ds == null ? null : point2Ds.ToList().ConvertAll(x => x == null ? null : new Point2D(x));
        }

        public GFunction(GFunction gFunction)
            : this(gFunction?.point2Ds)
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

        public TableModifier GetTableModifier()
        {
            string columnName_1 = "t/ts";
            string columnName_2 = "g-value";

            TableModifier result = new TableModifier(ArithmeticOperator.Multiplication, new string[] { columnName_1, columnName_2 });
            if (point2Ds != null)
            {
                Dictionary<string, double> dictionary = new Dictionary<string, double>();
                foreach (Point2D point2D in point2Ds)
                {
                    dictionary[columnName_1] = point2D.X;
                    dictionary[columnName_2] = point2D.Y;

                    result.AddValues(dictionary);
                }
            }

            return result;
        }

        public int Count
        {
            get
            {
                return point2Ds.Count;
            }
        }

        public double GetDimensionlessTime(int index)
        {
            return point2Ds[index].X;
        }

        public double GetThemalResponseFactor(int index)
        {
            return point2Ds[index].Y;
        }

        public List<double> GetDimensionlessTimes()
        {
            return point2Ds?.ConvertAll(x => x.X);
        }

        public List<double> GetThemalResponseFactors()
        {
            return point2Ds?.ConvertAll(x => x.Y);
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