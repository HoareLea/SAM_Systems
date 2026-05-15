// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemValve : SystemComponent, ILiquidSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignCapacitySignal { get; set; }
        public double DesignFlowRate { get; set; }
        public double DesignPressureDrop { get; set; }

        public string ScheduleName { get; set; }

        public SystemValve(string name)
            : base(name)
        {

        }

        public SystemValve(SystemValve systemValve)
            : base(systemValve)
        {
            if(systemValve != null)
            {
                Capacity = systemValve.Capacity;
                DesignCapacitySignal = systemValve.DesignCapacitySignal;
                DesignFlowRate = systemValve.DesignFlowRate;
                DesignPressureDrop = systemValve.DesignPressureDrop;
                ScheduleName = systemValve.ScheduleName;
            }
        }

        public SystemValve(System.Guid guid, SystemValve systemValve)
            : base(guid, systemValve)
        {
            if (systemValve != null)
            {
                Capacity = systemValve.Capacity;
                DesignCapacitySignal = systemValve.DesignCapacitySignal;
                DesignFlowRate = systemValve.DesignFlowRate;
                DesignPressureDrop = systemValve.DesignPressureDrop;
                ScheduleName = systemValve.ScheduleName;
            }
        }

        public SystemValve(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
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

            if(jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignCapacitySignal"))
            {
                DesignCapacitySignal = jObject["DesignCapacitySignal"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignFlowRate"))
            {
                DesignFlowRate = jObject["DesignFlowRate"]?.GetValue<double>() ?? default(double);
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
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignCapacitySignal))
            {
                result.Add("DesignCapacitySignal", DesignCapacitySignal);
            }

            if (!double.IsNaN(DesignFlowRate))
            {
                result.Add("DesignFlowRate", DesignFlowRate);
            }

            if (!double.IsNaN(DesignPressureDrop))
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
            return new SystemValve(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}