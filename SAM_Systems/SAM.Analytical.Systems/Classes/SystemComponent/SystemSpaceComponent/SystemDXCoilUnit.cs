// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoilUnit : SystemSpaceComponent
    {
        public ISizableValue HeatingDuty { get; set; }
        public ISizableValue CoolingDuty { get; set; }
        public ModifiableValue BypassFactor { get; set; }
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

        public SystemDXCoilUnit(string name)
            : base(name)
        {
        }

        public SystemDXCoilUnit(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemDXCoilUnit(SystemDXCoilUnit systemDXCoilUnit)
            : base(systemDXCoilUnit)
        {
            if (systemDXCoilUnit != null)
            {
                HeatingDuty = systemDXCoilUnit.HeatingDuty;
                CoolingDuty = systemDXCoilUnit.CoolingDuty;
                BypassFactor = systemDXCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemDXCoilUnit.OverallEfficiency?.Clone();
                HeatGainFactor = systemDXCoilUnit.HeatGainFactor;
                Pressure = systemDXCoilUnit.Pressure;
                DesignFlowRate = systemDXCoilUnit.DesignFlowRate?.Clone();
                DesignFlowType = systemDXCoilUnit.DesignFlowType;
                MinimumFlowRate = systemDXCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDXCoilUnit.MinimumFlowType;
                ZonePosition = systemDXCoilUnit.ZonePosition;
                ControlMethod = systemDXCoilUnit.ControlMethod;
                PartLoad = systemDXCoilUnit.PartLoad?.Clone();
                ScheduleName = systemDXCoilUnit.ScheduleName;
            }
        }

        public SystemDXCoilUnit(System.Guid guid, SystemDXCoilUnit systemDXCoilUnit)
            : base(guid, systemDXCoilUnit)
        {
            if (systemDXCoilUnit != null)
            {
                HeatingDuty = systemDXCoilUnit.HeatingDuty;
                CoolingDuty = systemDXCoilUnit.CoolingDuty;
                BypassFactor = systemDXCoilUnit.BypassFactor?.Clone();
                OverallEfficiency = systemDXCoilUnit.OverallEfficiency?.Clone();
                HeatGainFactor = systemDXCoilUnit.HeatGainFactor;
                Pressure = systemDXCoilUnit.Pressure;
                DesignFlowRate = systemDXCoilUnit.DesignFlowRate?.Clone();
                DesignFlowType = systemDXCoilUnit.DesignFlowType;
                MinimumFlowRate = systemDXCoilUnit.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDXCoilUnit.MinimumFlowType;
                ZonePosition = systemDXCoilUnit.ZonePosition;
                ControlMethod = systemDXCoilUnit.ControlMethod;
                PartLoad = systemDXCoilUnit.PartLoad?.Clone();
                ScheduleName = systemDXCoilUnit.ScheduleName;
            }
        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.Out, 1),
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

            if (jObject.ContainsKey("DesignFlowType"))
            {
                DesignFlowType = Core.Query.Enum<FlowRateType>(jObject["DesignFlowType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("MinimumFlowRate"))
            {
                MinimumFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["MinimumFlowRate"] as JsonObject);
            }

            if (jObject.ContainsKey("MinimumFlowType"))
            {
                MinimumFlowType = Core.Query.Enum<FlowRateType>(jObject["MinimumFlowType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ZonePosition"))
            {
                ZonePosition = Core.Query.Enum<SystemSpaceComponentPosition>(jObject["ZonePosition"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ControlMethod"))
            {
                ControlMethod = Core.Query.Enum<FanCoilControlMethod>(jObject["ControlMethod"]?.GetValue<string>() ?? null);
            }

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
            return new SystemDXCoilUnit(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}

