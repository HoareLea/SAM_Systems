using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class ProfileSetpoint : Setpoint
    {
        private List<Point2D> point2Ds = new List<Point2D>();

        public ProfileSetpoint()
            : base()
        {

        }

        public ProfileSetpoint(ProfileSetpoint profileSetpoint)
            :base(profileSetpoint)
        {
            if(profileSetpoint != null)
            {
                foreach(Point2D point2D in profileSetpoint.point2Ds)
                {
                    point2Ds.Add(point2D.Clone<Point2D>());
                }
            }
        }

        public ProfileSetpoint(JsonObject jObject)
            : base(jObject)
        {

        }

        public Range<double> InputRange
        {
            get
            {
                if(point2Ds == null || point2Ds.Count == 0)
                {
                    return null;
                }

                List<double> values = point2Ds.ConvertAll(x => x.X);

                return new Range<double>(values.Min(), values.Max());
            }
        }

        public Range<double> OutputRange
        {
            get
            {
                if (point2Ds == null || point2Ds.Count == 0)
                {
                    return null;
                }

                List<double> values = point2Ds.ConvertAll(x => x.Y);

                return new Range<double>(values.Min(), values.Max());
            }
        }

        public bool Add(double input, double output)
        {
            if(double.IsNaN(input) || double.IsNaN(output))
            {
                return false;
            }

            if(output > 1 || output < 0)
            {
                return false;
            }

            point2Ds.Add(new Point2D(input, output));
            return true;
        }

        public List<Point2D> Point2Ds
        {
            get
            {
                if(point2Ds == null)
                {
                    return null;
                }

                return point2Ds.ConvertAll(x => x.Clone<Point2D>());
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Point2Ds"))
            {
                JsonArray jArray = jObject["Point2Ds"] as JsonArray;
                if(jArray != null)
                {
                    point2Ds = new List<Point2D>();
                    foreach(JsonNode jsonNode in jArray)
                    {
                        if (!(jsonNode is JsonObject jObject_Point2D))
                        {
                            continue;
                        }

                        point2Ds.Add(new Point2D(jObject_Point2D));
                    }
                }
            }


            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return null;
            }

            if(point2Ds != null)
            {
                JsonArray jArray = new JsonArray();
                foreach(Point2D point2D in point2Ds)
                {
                    jArray.Add(point2D.ToJsonObject());
                }

                result.Add("Point2Ds", jArray);
            }

            return result;
        }
    }
}
