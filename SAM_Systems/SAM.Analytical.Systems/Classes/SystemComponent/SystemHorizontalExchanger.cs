// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Horizontal GHE, Heat Rejection (Liquid Side)
    /// </summary>
    public class SystemHorizontalExchanger : SystemComponent, ILiquidSystemComponent
    {
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public double GroundDensity { get; set; }
        public double GroundHeatCapacity { get; set; }
        public double GroundConductivity { get; set; }
        public double GroundSolarReflectance { get; set; }
        public double InsidePipeDiameter { get; set; }
        public double OutsidePipeDiameter { get; set; }
        public double PipeConductivity { get; set; }
        public double PipeLength { get; set; }
        public double PipeSeparation { get; set; }
        public double PipeDepth { get; set; }

        public SystemHorizontalExchanger(string name)
            : base(name)
        {

        }

        public SystemHorizontalExchanger(SystemHorizontalExchanger systemHorizontalExchanger)
            : base(systemHorizontalExchanger)
        {
            if (systemHorizontalExchanger != null)
            {
                DesignPressureDrop = systemHorizontalExchanger.DesignPressureDrop;
                Capacity = systemHorizontalExchanger.Capacity;
                GroundDensity = systemHorizontalExchanger.GroundDensity;
                GroundHeatCapacity = systemHorizontalExchanger.GroundHeatCapacity;
                GroundConductivity = systemHorizontalExchanger.GroundConductivity;
                GroundSolarReflectance = systemHorizontalExchanger.GroundSolarReflectance;
                InsidePipeDiameter = systemHorizontalExchanger.InsidePipeDiameter;
                OutsidePipeDiameter = systemHorizontalExchanger.OutsidePipeDiameter;
                PipeConductivity = systemHorizontalExchanger.PipeConductivity;
                PipeLength = systemHorizontalExchanger.PipeLength;
                PipeSeparation = systemHorizontalExchanger.PipeSeparation;
                PipeDepth = systemHorizontalExchanger.PipeDepth;
            }
        }

        public SystemHorizontalExchanger(System.Guid guid, SystemHorizontalExchanger systemHorizontalExchanger)
            : base(guid, systemHorizontalExchanger)
        {
            if (systemHorizontalExchanger != null)
            {
                DesignPressureDrop = systemHorizontalExchanger.DesignPressureDrop;
                Capacity = systemHorizontalExchanger.Capacity;
                GroundDensity = systemHorizontalExchanger.GroundDensity;
                GroundHeatCapacity = systemHorizontalExchanger.GroundHeatCapacity;
                GroundConductivity = systemHorizontalExchanger.GroundConductivity;
                GroundSolarReflectance = systemHorizontalExchanger.GroundSolarReflectance;
                InsidePipeDiameter = systemHorizontalExchanger.InsidePipeDiameter;
                OutsidePipeDiameter = systemHorizontalExchanger.OutsidePipeDiameter;
                PipeConductivity = systemHorizontalExchanger.PipeConductivity;
                PipeLength = systemHorizontalExchanger.PipeLength;
                PipeSeparation = systemHorizontalExchanger.PipeSeparation;
                PipeDepth = systemHorizontalExchanger.PipeDepth;
            }
        }

        public SystemHorizontalExchanger(JsonObject jObject)
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

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }


            if (jObject.ContainsKey("GroundDensity"))
            {
                GroundDensity = jObject["GroundDensity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundHeatCapacity"))
            {
                GroundHeatCapacity = jObject["GroundHeatCapacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject["GroundConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundSolarReflectance"))
            {
                GroundSolarReflectance = jObject["GroundSolarReflectance"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("InsidePipeDiameter"))
            {
                InsidePipeDiameter = jObject["InsidePipeDiameter"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("OutsidePipeDiameter"))
            {
                OutsidePipeDiameter = jObject["OutsidePipeDiameter"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeConductivity"))
            {
                PipeConductivity = jObject["PipeConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeLength"))
            {
                PipeLength = jObject["PipeLength"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeSeparation"))
            {
                PipeSeparation = jObject["PipeSeparation"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeDepth"))
            {
                PipeDepth = jObject["PipeDepth"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return result;
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(GroundDensity))
            {
                result.Add("GroundDensity", GroundDensity);
            }

            if (!double.IsNaN(GroundHeatCapacity))
            {
                result.Add("GroundHeatCapacity", GroundHeatCapacity);
            }

            if (!double.IsNaN(GroundConductivity))
            {
                result.Add("GroundConductivity", GroundConductivity);
            }

            if (!double.IsNaN(GroundSolarReflectance))
            {
                result.Add("GroundSolarReflectance", GroundSolarReflectance);
            }

            if (!double.IsNaN(InsidePipeDiameter))
            {
                result.Add("InsidePipeDiameter", InsidePipeDiameter);
            }

            if (!double.IsNaN(OutsidePipeDiameter))
            {
                result.Add("OutsidePipeDiameter", OutsidePipeDiameter);
            }

            if (!double.IsNaN(PipeConductivity))
            {
                result.Add("PipeConductivity", PipeConductivity);
            }

            if (!double.IsNaN(PipeLength))
            {
                result.Add("PipeLength", PipeLength);
            }

            if (!double.IsNaN(PipeSeparation))
            {
                result.Add("PipeSeparation", PipeSeparation);
            }

            if (!double.IsNaN(PipeDepth))
            {
                result.Add("PipeDepth", PipeDepth);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemHorizontalExchanger(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}