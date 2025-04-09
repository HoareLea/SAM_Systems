using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemEconomiser : SystemComponent, IAirSystemComponent
    {
        public double Capacity { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public SizedFlowValue MinFreshAirRate { get; set; }
        public FlowRateType MinFreshAirType { get; set; }
        public ScheduleMode ScheduleMode { get; set; }
        public double DesignPressureDrop { get; set; }

        public string ScheduleName { get; set; }

        public SystemEconomiser(string name)
            : base(name)
        {

        }

        public SystemEconomiser(SystemEconomiser systemEconomiser)
            : base(systemEconomiser)
        {
            if(systemEconomiser != null)
            {
                Capacity = systemEconomiser.Capacity;
                DesignFlowRate = systemEconomiser.DesignFlowRate?.Clone();
                DesignFlowType = systemEconomiser.DesignFlowType;
                Setpoint = systemEconomiser.Setpoint?.Clone();   
                MinFreshAirRate = systemEconomiser?.MinFreshAirRate?.Clone();
                MinFreshAirType = systemEconomiser.MinFreshAirType;
                ScheduleMode = systemEconomiser.ScheduleMode;
                DesignPressureDrop = systemEconomiser.DesignPressureDrop;
                ScheduleName = systemEconomiser.ScheduleName;
            }
        }

        public SystemEconomiser(System.Guid guid, SystemEconomiser systemEconomiser)
            : base(guid, systemEconomiser)
        {
            if (systemEconomiser != null)
            {
                Capacity = systemEconomiser.Capacity;
                DesignFlowRate = systemEconomiser.DesignFlowRate?.Clone();
                DesignFlowType = systemEconomiser.DesignFlowType;
                Setpoint = systemEconomiser.Setpoint?.Clone();
                MinFreshAirRate = systemEconomiser?.MinFreshAirRate?.Clone();
                MinFreshAirType = systemEconomiser.MinFreshAirType;
                ScheduleMode = systemEconomiser.ScheduleMode;
                DesignPressureDrop = systemEconomiser.DesignPressureDrop;
                ScheduleName = systemEconomiser.ScheduleName;
            }
        }

        public SystemEconomiser(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject.Value<JObject>("DesignFlowRate"));
            }

            if (jObject.ContainsKey("DesignFlowType"))
            {
                DesignFlowType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("DesignFlowType"));
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("MinFreshAirRate"))
            {
                MinFreshAirRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject.Value<JObject>("MinFreshAirRate"));
            }

            if (jObject.ContainsKey("MinFreshAirType"))
            {
                MinFreshAirType = Core.Query.Enum<FlowRateType>(jObject.Value<string>("MinFreshAirType"));
            }

            if (jObject.ContainsKey("ScheduleMode"))
            {
                ScheduleMode = Core.Query.Enum<ScheduleMode>(jObject.Value<string>("ScheduleMode"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (DesignFlowRate != null)
            {
                result.Add("DesignFlowRate", DesignFlowRate.ToJObject());
            }

            result.Add("DesignFlowType", DesignFlowType.ToString());

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (MinFreshAirRate != null)
            {
                result.Add("MinFreshAirRate", MinFreshAirRate.ToJObject());
            }

            result.Add("MinFreshAirType", MinFreshAirType.ToString());

            result.Add("ScheduleMode", ScheduleMode.ToString());

            if (double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemEconomiser(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
