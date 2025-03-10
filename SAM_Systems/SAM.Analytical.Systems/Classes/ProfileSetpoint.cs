using Newtonsoft.Json.Linq;
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

        public ProfileSetpoint(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Point2Ds"))
            {
                JArray jArray = jObject.Value<JArray>("Point2Ds");
                if(jArray != null)
                {
                    point2Ds = new List<Point2D>();
                    foreach(JObject jObject_Point2D in jArray)
                    {
                        point2Ds.Add(new Point2D(jObject_Point2D));
                    }
                }
            }


            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return null;
            }

            if(point2Ds != null)
            {
                JArray jArray = new JArray();
                foreach(Point2D point2D in point2Ds)
                {
                    jArray.Add(point2D.ToJObject());
                }

                result.Add("Point2Ds", jArray);
            }

            return result;
        }
    }
}
