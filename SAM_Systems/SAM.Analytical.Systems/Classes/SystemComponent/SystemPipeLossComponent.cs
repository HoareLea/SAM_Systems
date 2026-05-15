using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

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

        public SystemPipeLossComponent(System.Guid guid, SystemPipeLossComponent systemPipeLossComponent)
            : base(guid, systemPipeLossComponent)
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

        public SystemPipeLossComponent(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Length"))
            {
                Length = jObject["Length"]?.GetValue<double>() ?? default(double);
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

            if (jObject.ContainsKey("InsulationThickness"))
            {
                InsulationThickness = jObject["InsulationThickness"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("InsulationConductivity"))
            {
                InsulationConductivity = jObject["InsulationConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AmbientTemperature"))
            {
                AmbientTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["AmbientTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("IsUnderground"))
            {
                IsUnderground = jObject["IsUnderground"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("GroundConductivity"))
            {
                GroundConductivity = jObject["GroundConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundHeatCapacity"))
            {
                GroundHeatCapacity = jObject["GroundHeatCapacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundDensity"))
            {
                GroundDensity = jObject["GroundDensity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundTemperature"))
            {
                GroundTemperature = jObject["GroundTemperature"]?.GetValue<double>() ?? default(double);
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
                result.Add("AmbientTemperature", AmbientTemperature.ToJsonObject());
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

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemPipeLossComponent(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
