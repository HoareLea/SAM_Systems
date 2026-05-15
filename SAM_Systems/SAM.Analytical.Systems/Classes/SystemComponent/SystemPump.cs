using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemPump : SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue OverallEfficiency { get; set; }
        
        public double Pressure { get; set; }

        public double DesignFlowRate { get; set; }

        public double Capacity { get; set; }

        public ModifiableValue PartLoad { get; set; }

        public FanControlType FanControlType { get; set; }

        public string ScheduleName { get; set; }

        public SystemPump(string name)
            : base(name)
        {

        }

        public SystemPump(SystemPump systemPump)
            : base(systemPump)
        {
            if(systemPump != null)
            {
                OverallEfficiency = systemPump.OverallEfficiency?.Clone();
                Pressure = systemPump.Pressure;
                DesignFlowRate = systemPump.DesignFlowRate;
                Capacity = systemPump.Capacity;
                PartLoad = systemPump.PartLoad?.Clone();
                FanControlType = systemPump.FanControlType;
                ScheduleName = systemPump.ScheduleName;
            }
        }

        public SystemPump(System.Guid guid, SystemPump systemPump)
            : base(guid, systemPump)
        {
            if (systemPump != null)
            {
                OverallEfficiency = systemPump.OverallEfficiency?.Clone();
                Pressure = systemPump.Pressure;
                DesignFlowRate = systemPump.DesignFlowRate;
                Capacity = systemPump.Capacity;
                PartLoad = systemPump.PartLoad?.Clone();
                FanControlType = systemPump.FanControlType;
                ScheduleName = systemPump.ScheduleName;
            }
        }

        public SystemPump(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("FanControlType"))
            {
                FanControlType = Core.Query.Enum<FanControlType>(jObject["FanControlType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("OverallEfficiency"))
            {
                OverallEfficiency = Core.Create.IJSAMObject<ModifiableValue>(jObject["OverallEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Pressure"))
            {
                Pressure = jObject["Pressure"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = jObject["DesignFlowRate"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Create.IJSAMObject<ModifiableValue>(jObject["PartLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            result.Add("FanControlType", FanControlType.ToString());

            if(OverallEfficiency != null)
            {
                result.Add("OverallEfficiency", OverallEfficiency.ToJsonObject());
            }

            if(!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (PartLoad != null)
            {
                result.Add("PartLoad", PartLoad.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemPump(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}