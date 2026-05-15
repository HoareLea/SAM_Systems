using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public class FunctionSchedule : Schedule
    {
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
                Cooling = functionSchedule.Cooling;
                Heating = functionSchedule.Heating;
                OccupancySensible = functionSchedule.OccupancySensible;
            }
        }

        public FunctionSchedule(JsonObject jObject)
            : base(jObject)
        {

        }

        public bool Cooling { get; set; }
        
        public bool Heating { get; set; }
        
        public bool OccupancySensible { get; set; }
        
        public ScheduleFunctionType ScheduleFunctionType { get; set; }
        
        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("ScheduleFunctionType"))
            {
                ScheduleFunctionType = Core.Query.Enum<ScheduleFunctionType>(jObject["ScheduleFunctionType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Heating"))
            {
                Heating = jObject["Heating"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("Cooling"))
            {
                Cooling = jObject["Cooling"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("OccupancySensible"))
            {
                OccupancySensible = jObject["OccupancySensible"]?.GetValue<bool>() ?? default(bool);
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
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
