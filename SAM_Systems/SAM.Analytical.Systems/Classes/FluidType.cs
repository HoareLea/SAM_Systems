// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class FluidType : SAMObject, Core.Systems.ISystemObject
    {
        public string Description { get; set; }
        public double SpecificHeatCapacity { get; set; }
        public double Density { get; set; }
        public double FreezingPoint { get; set; }

        public FluidType(string name)
            :base(name)
        {

        }

        public FluidType(FluidType fluidType)
            : base(fluidType)
        {
            if(fluidType != null)
            {
                Description = fluidType.Description;
                SpecificHeatCapacity = fluidType.SpecificHeatCapacity;
                Density = fluidType.Density;
                FreezingPoint = fluidType.FreezingPoint;
            }
        }

        public FluidType(JsonObject jObject)
            :base(jObject)
        {
            
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return false;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject["Description"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("SpecificHeatCapacity"))
            {
                SpecificHeatCapacity = jObject["SpecificHeatCapacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Density"))
            {
                Density = jObject["Density"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("FreezingPoint"))
            {
                FreezingPoint = jObject["FreezingPoint"]?.GetValue<double>() ?? default(double);
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

            if (Description != null)
            {
                result.Add("Description", Description);
            }

            if (!double.IsNaN(SpecificHeatCapacity))
            {
                result.Add("SpecificHeatCapacity", SpecificHeatCapacity);
            }

            if (!double.IsNaN(Density))
            {
                result.Add("Density", Density);
            }

            if (!double.IsNaN(FreezingPoint))
            {
                result.Add("FreezingPoint", FreezingPoint);
            }

            return result;
        }
    }
}