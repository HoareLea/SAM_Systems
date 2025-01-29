using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class FunctionSchedule : Schedule
    {
        public ScheduleFunctionType ScheduleFunctionType { get; set; }
        public bool Heating { get; set; }
        public bool Cooling { get; set; }
        public bool OccupancySensible { get; set; }

        public FunctionSchedule()
        {

        }

        public FunctionSchedule(string name)
            : base(name)
        {

        }

        public FunctionSchedule(FunctionSchedule functionSchedule)
            : base(functionSchedule)
        {
            if (functionSchedule != null)
            {
                ScheduleFunctionType = functionSchedule.ScheduleFunctionType;
            }
        }

        public FunctionSchedule(JObject jObject)
            : base(jObject)
        {

        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("ScheduleFunctionType"))
            {
                ScheduleFunctionType = Core.Query.Enum<ScheduleFunctionType>(jObject.Value<string>("ScheduleFunctionType"));
            }

            if (jObject.ContainsKey("Heating"))
            {
                Heating = jObject.Value<bool>("Heating");
            }

            if (jObject.ContainsKey("Cooling"))
            {
                Cooling = jObject.Value<bool>("Cooling");
            }

            if (jObject.ContainsKey("OccupancySensible"))
            {
                OccupancySensible = jObject.Value<bool>("OccupancySensible");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            result.Add("ScheduleFunctionType", ScheduleFunctionType.ToString());

            result.Add("Heating", Heating);

            result.Add("Cooling", Cooling);

            result.Add("OccupancySensible", OccupancySensible);

            return result;
        }
    }
}
