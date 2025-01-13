using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemSlinkyCoil : SystemComponent
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

        public SystemSlinkyCoil(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }


            if (jObject.ContainsKey("GroundDensity"))
            {
                GroundDensity = jObject.Value<double>("GroundDensity");
            }

            if (jObject.ContainsKey("GroundHeatCapacity"))
            {
                GroundHeatCapacity = jObject.Value<double>("GroundHeatCapacity");
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject.Value<double>("GroundConductivity");
            }

            if (jObject.ContainsKey("GroundSolarReflectance"))
            {
                GroundSolarReflectance = jObject.Value<double>("GroundSolarReflectance");
            }

            if (jObject.ContainsKey("InsidePipeDiameter"))
            {
                InsidePipeDiameter = jObject.Value<double>("InsidePipeDiameter");
            }

            if (jObject.ContainsKey("OutsidePipeDiameter"))
            {
                OutsidePipeDiameter = jObject.Value<double>("OutsidePipeDiameter"); 
            }

            if (jObject.ContainsKey("PipeConductivity"))
            {
                PipeConductivity = jObject.Value<double>("PipeConductivity");
            }

            if (jObject.ContainsKey("LoopPitch"))
            {
                LoopPitch = jObject.Value<double>("LoopPitch");
            }

            if (jObject.ContainsKey("LoopWidth"))
            {
                LoopWidth = jObject.Value<double>("LoopWidth");
            }

            if (jObject.ContainsKey("LoopHeight"))
            {
                LoopHeight = jObject.Value<double>("LoopHeight");
            }

            if (jObject.ContainsKey("IsUprightCoil"))
            {
                IsUprightCoil = jObject.Value<bool>("IsUprightCoil");
            }

            if (jObject.ContainsKey("FillDensity"))
            {
                FillDensity = jObject.Value<double>("FillDensity");
            }

            if (jObject.ContainsKey("FillHeatCapacity"))
            {
                FillHeatCapacity = jObject.Value<double>("FillHeatCapacity");
            }

            if (jObject.ContainsKey("FillConductivity"))
            {
                FillConductivity = jObject.Value<double>("FillConductivity");
            }

            if (jObject.ContainsKey("TrenchLength"))
            {
                TrenchLength = jObject.Value<double>("TrenchLength");
            }

            if (jObject.ContainsKey("TrenchDepth"))
            {
                TrenchDepth = jObject.Value<double>("TrenchDepth");
            }

            if (jObject.ContainsKey("TrenchWidth"))
            {
                TrenchWidth = jObject.Value<double>("TrenchWidth");
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
    }
}