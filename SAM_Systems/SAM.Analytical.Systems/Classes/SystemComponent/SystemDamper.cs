// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDamper : SystemComponent, IAirSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignCapacitySignal { get; set; }
        public SizedFlowValue DesignFlowRate { get; set; }
        public FlowRateType DesignFlowType { get; set; }
        public SizedFlowValue MinimumFlowRate { get; set; }
        public FlowRateType MinimumFlowType { get; set; }
        public double MinimumFlowFraction { get; set; }
        public double DesignPressureDrop { get; set; }

        public string ScheduleName { get; set; }

        public SystemDamper(string name)
            : base(name)
        {

        }

        public SystemDamper(SystemDamper systemDamper)
            : base(systemDamper)
        {
            if(systemDamper != null)
            {
                Capacity = systemDamper.Capacity;
                DesignCapacitySignal = systemDamper.DesignCapacitySignal;
                DesignFlowRate = systemDamper.DesignFlowRate?.Clone();
                DesignFlowType = systemDamper.DesignFlowType;
                MinimumFlowRate = systemDamper.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDamper.MinimumFlowType;
                MinimumFlowFraction = systemDamper.MinimumFlowFraction;
                DesignPressureDrop = systemDamper.DesignPressureDrop;
                ScheduleName = systemDamper.ScheduleName;
            }
        }

        public SystemDamper(System.Guid guid, SystemDamper systemDamper)
            : base(guid, systemDamper)
        {
            if (systemDamper != null)
            {
                Capacity = systemDamper.Capacity;
                DesignCapacitySignal = systemDamper.DesignCapacitySignal;
                DesignFlowRate = systemDamper.DesignFlowRate?.Clone();
                DesignFlowType = systemDamper.DesignFlowType;
                MinimumFlowRate = systemDamper.MinimumFlowRate?.Clone();
                MinimumFlowType = systemDamper.MinimumFlowType;
                MinimumFlowFraction = systemDamper.MinimumFlowFraction;
                DesignPressureDrop = systemDamper.DesignPressureDrop;
                ScheduleName = systemDamper.ScheduleName;
            }
        }

        public SystemDamper(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(),
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

            if (jObject.ContainsKey("DesignCapacitySignal"))
            {
                DesignCapacitySignal = jObject["DesignCapacitySignal"]?.GetValue<double>() ?? default(double);
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

            if (jObject.ContainsKey("MinimumFlowFraction"))
            {
                MinimumFlowFraction = jObject["MinimumFlowFraction"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
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

            if (double.IsNaN(DesignCapacitySignal))
            {
                result.Add("DesignCapacitySignal", DesignCapacitySignal);
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

            if (double.IsNaN(MinimumFlowFraction))
            {
                result.Add("MinimumFlowFraction", MinimumFlowFraction);
            }

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
            return new SystemDamper(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
