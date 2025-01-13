using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Surface Water Exchanger, Heat Rejection (Liquid side)
    /// </summary>
    public class SystemSurfaceWaterExchanger : SystemComponent
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

        public SystemSurfaceWaterExchanger(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("PondVolume"))
            {
                PondVolume = jObject.Value<double>("PondVolume");
            }

            if (jObject.ContainsKey("PondSurfaceArea"))
            {
                PondSurfaceArea = jObject.Value<double>("PondSurfaceArea");
            }

            if (jObject.ContainsKey("PondPerimeter"))
            {
                PondPerimeter = jObject.Value<double>("PondPerimeter");
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject.Value<double>("GroundConductivity");
            }

            if (jObject.ContainsKey("WaterTableDepth"))
            {
                WaterTableDepth = jObject.Value<double>("WaterTableDepth");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
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
                result.Add("Efficiency", Efficiency.ToJObject());
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
    }
}