// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSlinkyCoil : SystemComponent, ILiquidSystemComponent
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
        public double LoopPitch { get; set; }
        public double LoopWidth { get; set; }
        public double LoopHeight { get; set; }
        public bool IsUprightCoil { get; set; }
        public double FillDensity { get; set; }
        public double FillHeatCapacity { get; set; }
        public double FillConductivity { get; set; }
        public double TrenchLength { get; set; }
        public double TrenchDepth { get; set; }
        public double TrenchWidth { get; set; }

        public SystemSlinkyCoil(string name)
            : base(name)
        {

        }

        public SystemSlinkyCoil(SystemSlinkyCoil systemSlinkyCoil)
            : base(systemSlinkyCoil)
        {
            if(systemSlinkyCoil != null)
            {
                DesignPressureDrop = systemSlinkyCoil.DesignPressureDrop;
                Capacity = systemSlinkyCoil.Capacity;
                GroundDensity = systemSlinkyCoil.GroundDensity;
                GroundHeatCapacity = systemSlinkyCoil.GroundHeatCapacity;
                GroundConductivity = systemSlinkyCoil.GroundConductivity;
                GroundSolarReflectance = systemSlinkyCoil.GroundSolarReflectance;
                InsidePipeDiameter = systemSlinkyCoil.InsidePipeDiameter;
                OutsidePipeDiameter = systemSlinkyCoil.OutsidePipeDiameter;
                PipeConductivity = systemSlinkyCoil.PipeConductivity;
                LoopPitch = systemSlinkyCoil.LoopPitch;
                LoopWidth = systemSlinkyCoil.LoopWidth;
                LoopHeight = systemSlinkyCoil.LoopHeight;
                IsUprightCoil = systemSlinkyCoil.IsUprightCoil;
                FillDensity = systemSlinkyCoil.FillDensity;
                FillHeatCapacity = systemSlinkyCoil.FillHeatCapacity;
                FillConductivity = systemSlinkyCoil.FillConductivity;
                TrenchLength = systemSlinkyCoil.TrenchLength;
                TrenchDepth = systemSlinkyCoil.TrenchDepth;
                TrenchWidth = systemSlinkyCoil.TrenchWidth;
            }
        }

        public SystemSlinkyCoil(Guid guid, SystemSlinkyCoil systemSlinkyCoil)
            : base(guid, systemSlinkyCoil)
        {
            if (systemSlinkyCoil != null)
            {
                DesignPressureDrop = systemSlinkyCoil.DesignPressureDrop;
                Capacity = systemSlinkyCoil.Capacity;
                GroundDensity = systemSlinkyCoil.GroundDensity;
                GroundHeatCapacity = systemSlinkyCoil.GroundHeatCapacity;
                GroundConductivity = systemSlinkyCoil.GroundConductivity;
                GroundSolarReflectance = systemSlinkyCoil.GroundSolarReflectance;
                InsidePipeDiameter = systemSlinkyCoil.InsidePipeDiameter;
                OutsidePipeDiameter = systemSlinkyCoil.OutsidePipeDiameter;
                PipeConductivity = systemSlinkyCoil.PipeConductivity;
                LoopPitch = systemSlinkyCoil.LoopPitch;
                LoopWidth = systemSlinkyCoil.LoopWidth;
                LoopHeight = systemSlinkyCoil.LoopHeight;
                IsUprightCoil = systemSlinkyCoil.IsUprightCoil;
                FillDensity = systemSlinkyCoil.FillDensity;
                FillHeatCapacity = systemSlinkyCoil.FillHeatCapacity;
                FillConductivity = systemSlinkyCoil.FillConductivity;
                TrenchLength = systemSlinkyCoil.TrenchLength;
                TrenchDepth = systemSlinkyCoil.TrenchDepth;
                TrenchWidth = systemSlinkyCoil.TrenchWidth;
            }
        }

        public SystemSlinkyCoil(JsonObject jObject)
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

            if (jObject.ContainsKey("LoopPitch"))
            {
                LoopPitch = jObject["LoopPitch"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("LoopWidth"))
            {
                LoopWidth = jObject["LoopWidth"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("LoopHeight"))
            {
                LoopHeight = jObject["LoopHeight"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("IsUprightCoil"))
            {
                IsUprightCoil = jObject["IsUprightCoil"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("FillDensity"))
            {
                FillDensity = jObject["FillDensity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("FillHeatCapacity"))
            {
                FillHeatCapacity = jObject["FillHeatCapacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("FillConductivity"))
            {
                FillConductivity = jObject["FillConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("TrenchLength"))
            {
                TrenchLength = jObject["TrenchLength"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("TrenchDepth"))
            {
                TrenchDepth = jObject["TrenchDepth"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("TrenchWidth"))
            {
                TrenchWidth = jObject["TrenchWidth"]?.GetValue<double>() ?? default(double);
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

            if (!double.IsNaN(LoopPitch))
            {
                result.Add("LoopPitch", LoopPitch);
            }

            if (!double.IsNaN(LoopWidth))
            {
                result.Add("LoopWidth", LoopWidth);
            }

            if (!double.IsNaN(LoopHeight))
            {
                result.Add("LoopHeight", LoopHeight);
            }

            if (IsUprightCoil)
            {
                result.Add("IsUprightCoil", IsUprightCoil);
            }

            if (!double.IsNaN(FillDensity))
            {
                result.Add("FillDensity", FillDensity);
            }

            if (!double.IsNaN(FillHeatCapacity))
            {
                result.Add("FillHeatCapacity", FillHeatCapacity);
            }

            if (!double.IsNaN(FillConductivity))
            {
                result.Add("FillConductivity", FillConductivity);
            }

            if (!double.IsNaN(TrenchLength))
            {
                result.Add("TrenchLength", TrenchLength);
            }

            if (!double.IsNaN(TrenchDepth))
            {
                result.Add("TrenchDepth", TrenchDepth);
            }

            if (!double.IsNaN(TrenchWidth))
            {
                result.Add("TrenchWidth", TrenchWidth);
            }


            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSlinkyCoil(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}