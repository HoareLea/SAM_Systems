using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Surface Water Exchanger, Heat Rejection (Liquid side)
    /// </summary>
    public class SystemSurfaceWaterExchanger : SystemComponent, ILiquidSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public double PondVolume { get; set; }
        public double PondSurfaceArea { get; set; }
        public double PondPerimeter { get; set; }
        public double GroundConductivity { get; set; }
        public double WaterTableDepth { get; set; }

        public SystemSurfaceWaterExchanger(string name)
            : base(name)
        {

        }

        public SystemSurfaceWaterExchanger(SystemSurfaceWaterExchanger systemSurfaceWaterExchanger)
            : base(systemSurfaceWaterExchanger)
        {
            if (systemSurfaceWaterExchanger != null)
            {
                Capacity = systemSurfaceWaterExchanger.Capacity;
                DesignPressureDrop = systemSurfaceWaterExchanger.DesignPressureDrop;
                Efficiency = systemSurfaceWaterExchanger.Efficiency?.Clone();
                PondVolume = systemSurfaceWaterExchanger.PondVolume;
                PondSurfaceArea = systemSurfaceWaterExchanger.PondSurfaceArea;
                PondPerimeter = systemSurfaceWaterExchanger.PondPerimeter;
                GroundConductivity = systemSurfaceWaterExchanger.GroundConductivity;
                WaterTableDepth = systemSurfaceWaterExchanger.WaterTableDepth;
            }
        }

        public SystemSurfaceWaterExchanger(System.Guid guid, SystemSurfaceWaterExchanger systemSurfaceWaterExchanger)
            : base(guid, systemSurfaceWaterExchanger)
        {
            if (systemSurfaceWaterExchanger != null)
            {
                Capacity = systemSurfaceWaterExchanger.Capacity;
                DesignPressureDrop = systemSurfaceWaterExchanger.DesignPressureDrop;
                Efficiency = systemSurfaceWaterExchanger.Efficiency?.Clone();
                PondVolume = systemSurfaceWaterExchanger.PondVolume;
                PondSurfaceArea = systemSurfaceWaterExchanger.PondSurfaceArea;
                PondPerimeter = systemSurfaceWaterExchanger.PondPerimeter;
                GroundConductivity = systemSurfaceWaterExchanger.GroundConductivity;
                WaterTableDepth = systemSurfaceWaterExchanger.WaterTableDepth;
            }
        }

        public SystemSurfaceWaterExchanger(JsonObject jObject)
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

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("PondVolume"))
            {
                PondVolume = jObject["PondVolume"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PondSurfaceArea"))
            {
                PondSurfaceArea = jObject["PondSurfaceArea"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PondPerimeter"))
            {
                PondPerimeter = jObject["PondPerimeter"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject["GroundConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("WaterTableDepth"))
            {
                WaterTableDepth = jObject["WaterTableDepth"]?.GetValue<double>() ?? default(double);
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

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (!double.IsNaN(PondVolume))
            {
                result.Add("PondVolume", PondVolume);
            }

            if (!double.IsNaN(PondSurfaceArea))
            {
                result.Add("PondSurfaceArea", PondSurfaceArea);
            }

            if (!double.IsNaN(PondPerimeter))
            {
                result.Add("PondPerimeter", PondPerimeter);
            }

            if (!double.IsNaN(GroundConductivity))
            {
                result.Add("GroundConductivity", GroundConductivity);
            }

            if (!double.IsNaN(WaterTableDepth))
            {
                result.Add("WaterTableDepth", WaterTableDepth);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSurfaceWaterExchanger(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}