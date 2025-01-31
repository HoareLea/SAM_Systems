using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemPipeLossComponent : SystemComponent, ILiquidSystemComponent
    {
        public double DesignPressureDrop { get; set; }
        public double Capacity { get; set; }
        public double Length { get; set; }
        public double InsidePipeDiameter { get; set; }
        public double OutsidePipeDiameter { get; set; }
        public double PipeConductivity { get; set; }
        public double InsulationThickness { get; set; }
        public double InsulationConductivity { get; set; }
        public ModifiableValue AmbientTemperature { get; set; }

        public bool IsUnderground { get; set; }
        public double GroundConductivity { get; set; }
        public double GroundHeatCapacity { get; set; }
        public double GroundDensity { get; set; }
        
        /// <summary>
        /// -1000 means comes from TSD
        /// </summary>
        public double GroundTemperature { get; set; }

        public SystemPipeLossComponent(SystemPipeLossComponent systemPipeLossComponent)
            : base(systemPipeLossComponent)
        {
            if (systemPipeLossComponent != null)
            {
                DesignPressureDrop = systemPipeLossComponent.DesignPressureDrop;
                Capacity = systemPipeLossComponent.Capacity;
                Length = systemPipeLossComponent.Length;
                InsidePipeDiameter = systemPipeLossComponent.InsidePipeDiameter;
                OutsidePipeDiameter = systemPipeLossComponent.OutsidePipeDiameter;
                PipeConductivity = systemPipeLossComponent.PipeConductivity;
                InsulationThickness = systemPipeLossComponent.InsulationThickness;
                InsulationConductivity = systemPipeLossComponent.InsulationConductivity;
                AmbientTemperature = systemPipeLossComponent.AmbientTemperature?.Clone();

                IsUnderground = systemPipeLossComponent.IsUnderground;
                GroundConductivity = systemPipeLossComponent.GroundConductivity;
                GroundHeatCapacity = systemPipeLossComponent.GroundHeatCapacity;
                GroundDensity = systemPipeLossComponent.GroundDensity;
                GroundTemperature = systemPipeLossComponent.GroundTemperature;
            }
        }

        public SystemPipeLossComponent(string name)
            : base(name)
        {

        }

        public SystemPipeLossComponent(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1)
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("Length"))
            {
                Length = jObject.Value<double>("Length");
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

            if (jObject.ContainsKey("InsulationThickness"))
            {
                InsulationThickness = jObject.Value<double>("InsulationThickness");
            }

            if (jObject.ContainsKey("InsulationConductivity"))
            {
                InsulationConductivity = jObject.Value<double>("InsulationConductivity");
            }

            if (jObject.ContainsKey("AmbientTemperature"))
            {
                AmbientTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AmbientTemperature"));
            }

            if (jObject.ContainsKey("IsUnderground"))
            {
                IsUnderground = jObject.Value<bool>("IsUnderground");
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject.Value<double>("GroundConductivity");
            }

            if (jObject.ContainsKey("GroundHeatCapacity"))
            {
                GroundHeatCapacity = jObject.Value<double>("GroundHeatCapacity");
            }

            if (jObject.ContainsKey("GroundDensity"))
            {
                GroundDensity = jObject.Value<double>("GroundDensity");
            }

            if (jObject.ContainsKey("GroundTemperature"))
            {
                GroundTemperature = jObject.Value<double>("GroundTemperature");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(Length))
            {
                result.Add("Length", Length);
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

            if (!double.IsNaN(InsulationThickness))
            {
                result.Add("InsulationThickness", InsulationThickness);
            }

            if (!double.IsNaN(InsulationConductivity))
            {
                result.Add("InsulationConductivity", InsulationConductivity);
            }

            if(AmbientTemperature != null)
            {
                result.Add("AmbientTemperature", AmbientTemperature.ToJObject());
            }

            result.Add("IsUnderground", IsUnderground);

            if (!double.IsNaN(GroundConductivity))
            {
                result.Add("GroundConductivity", GroundConductivity);
            }

            if (!double.IsNaN(GroundHeatCapacity))
            {
                result.Add("GroundHeatCapacity", GroundHeatCapacity);
            }

            if (!double.IsNaN(GroundDensity))
            {
                result.Add("GroundDensity", GroundDensity);
            }

            if (!double.IsNaN(GroundTemperature))
            {
                result.Add("GroundTemperature", GroundTemperature);
            }

            return result;
        }
    }
}
