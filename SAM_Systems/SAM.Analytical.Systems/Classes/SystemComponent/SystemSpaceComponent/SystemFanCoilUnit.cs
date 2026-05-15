using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemFanCoilUnit : SystemSpaceComponent
    {
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public ModifiableValue HeatingEfficiency { get; set; }
        public ModifiableValue OverallEfficiency { get; set; }
        public double HeatGainFactor { get; set; }
        public double Pressure { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SizedFlowValue MinimumFlowRate { get; set; }
        public FlowRateType MinimumFlowType { get; set; }
        public SystemSpaceComponentPosition ZonePosition { get; set; }
        public FanCoilControlMethod ControlMethod { get; set; }
        public ModifiableValue PartLoad { get; set; }

        public string ScheduleName { get; set; }


        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (

                );
            }
        }

        public SystemFanCoilUnit(string name)
            : base(name)
        {
        }

        public SystemFanCoilUnit(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemFanCoilUnit(SystemFanCoilUnit systemFanCoilUnit)
            : base(systemFanCoilUnit)
        {
            if (systemFanCoilUnit != null)
            {
                HeatingDuty = systemFanCoilUnit.HeatingDuty?.Clone();
                CoolingDuty = systemFanCoilUnit.CoolingDuty?.Clone();
                BypassFactor = systemFanCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemFanCoilUnit.OverallEfficiency?.Clone();
                HeatingEfficiency = systemFanCoilUnit.HeatingEfficiency?.Clone();
                HeatGainFactor = systemFanCoilUnit.HeatGainFactor;
                Pressure = systemFanCoilUnit.Pressure;
                DesignFlowRate = systemFanCoilUnit.DesignFlowRate.Clone();
                DesignFlowType = systemFanCoilUnit.DesignFlowType;
                MinimumFlowRate = systemFanCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemFanCoilUnit.MinimumFlowType;
                ZonePosition = systemFanCoilUnit.ZonePosition;
                ControlMethod = systemFanCoilUnit.ControlMethod;
                PartLoad = systemFanCoilUnit.PartLoad?.Clone();
                ScheduleName = systemFanCoilUnit.ScheduleName;
            }
        }

        public SystemFanCoilUnit(System.Guid guid, SystemFanCoilUnit systemFanCoilUnit)
            : base(guid, systemFanCoilUnit)
        {
            if (systemFanCoilUnit != null)
            {
                HeatingDuty = systemFanCoilUnit.HeatingDuty?.Clone();
                CoolingDuty = systemFanCoilUnit.CoolingDuty?.Clone();
                BypassFactor = systemFanCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemFanCoilUnit.OverallEfficiency?.Clone();
                HeatingEfficiency = systemFanCoilUnit.HeatingEfficiency?.Clone();
                HeatGainFactor = systemFanCoilUnit.HeatGainFactor;
                Pressure = systemFanCoilUnit.Pressure;
                DesignFlowRate = systemFanCoilUnit.DesignFlowRate.Clone();
                DesignFlowType = systemFanCoilUnit.DesignFlowType;
                MinimumFlowRate = systemFanCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemFanCoilUnit.MinimumFlowType;
                ZonePosition = systemFanCoilUnit.ZonePosition;
                ControlMethod = systemFanCoilUnit.ControlMethod;
                PartLoad = systemFanCoilUnit.PartLoad?.Clone();
                ScheduleName = systemFanCoilUnit.ScheduleName;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["HeatingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject["CoolingDuty"] as JsonObject);
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject["BypassFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatingEfficiency"))
            {
                HeatingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["HeatingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("OverallEfficiency"))
            {
                OverallEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["OverallEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("HeatGainFactor"))
            {
                HeatGainFactor = jObject["HeatGainFactor"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Pressure"))
            {
                Pressure = jObject["Pressure"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["DesignFlowRate"] as JsonObject);
            }

            DesignFlowType = Core.Query.Enum<FlowRateType>(jObject["DesignFlowType"]?.GetValue<string>() ?? null);

            if (jObject.ContainsKey("MinimumFlowRate"))
            {
                MinimumFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["MinimumFlowRate"] as JsonObject);
            }

            MinimumFlowType = Core.Query.Enum<FlowRateType>(jObject["MinimumFlowType"]?.GetValue<string>() ?? null);

            ZonePosition = Core.Query.Enum<SystemSpaceComponentPosition>(jObject["ZonePosition"]?.GetValue<string>() ?? null);

            ControlMethod = Core.Query.Enum<FanCoilControlMethod>(jObject["ControlMethod"]?.GetValue<string>() ?? null);

            if (jObject.ContainsKey("PartLoad"))
            {
                PartLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["PartLoad"] as JsonObject);
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

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJsonObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJsonObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJsonObject());
            }

            if (HeatingEfficiency != null)
            {
                result.Add("HeatingEfficiency", HeatingEfficiency.ToJsonObject());
            }

            if (OverallEfficiency != null)
            {
                result.Add("OverallEfficiency", OverallEfficiency.ToJsonObject());
            }

            if (!double.IsNaN(HeatGainFactor))
            {
                result.Add("HeatGainFactor", HeatGainFactor);
            }

            if (!double.IsNaN(Pressure))
            {
                result.Add("Pressure", Pressure);
            }

            if (DesignFlowRate != null)
            {
                result.Add("DesignFlowRate", DesignFlowRate.ToJsonObject());
            }

            result.Add("DesignFlowType", DesignFlowType.ToString());

            if (MinimumFlowRate != null)
            {
                result.Add("MinimumFlowRate", MinimumFlowRate.ToJsonObject());
            }

            result.Add("MinimumFlowType", MinimumFlowType.ToString());

            result.Add("ZonePosition", ZonePosition.ToString());

            result.Add("ControlMethod", ControlMethod.ToString());

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
            return new SystemFanCoilUnit(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
