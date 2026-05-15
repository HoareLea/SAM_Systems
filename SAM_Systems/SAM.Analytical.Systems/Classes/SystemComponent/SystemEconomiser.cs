// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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

        public SystemEconomiser(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["DesignFlowRate"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignFlowType"))
            {
                DesignFlowType = Core.Query.Enum<FlowRateType>(jObject["DesignFlowType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("MinFreshAirRate"))
            {
                MinFreshAirRate = Core.Query.IJSAMObject<SizedFlowValue>(jObject["MinFreshAirRate"] as JsonObject);
            }

            if (jObject.ContainsKey("MinFreshAirType"))
            {
                MinFreshAirType = Core.Query.Enum<FlowRateType>(jObject["MinFreshAirType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ScheduleMode"))
            {
                ScheduleMode = Core.Query.Enum<ScheduleMode>(jObject["ScheduleMode"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
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
                result.Add("DesignFlowRate", DesignFlowRate.ToJsonObject());
            }

            result.Add("DesignFlowType", DesignFlowType.ToString());

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (MinFreshAirRate != null)
            {
                result.Add("MinFreshAirRate", MinFreshAirRate.ToJsonObject());
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
