using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemVerticalBorehole : SystemComponent, ILiquidSystemComponent
    {
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public double Length { get; set; }
        public double Diameter { get; set; }
        public double GroundConductivity { get; set; }
        public double GroundHeatCapacity { get; set; }
        public double GroundDensity { get; set; }
        public int NumberOfBoreholes { get; set; }
        public GFunction GFunction { get; set; }
        public double GFunctionReferenceRatio { get; set; }
        public double PipeInDiameter { get; set; }
        public double PipeOutDiameter { get; set; }
        public double PipeConductivity { get; set; }
        public double GroutConductivity { get; set; }
        public double GroundTemperatureAve { get; set; }

        public SystemVerticalBorehole(string name)
            : base(name)
        {

        }

        public SystemVerticalBorehole(SystemVerticalBorehole systemVerticalBorehole)
            : base(systemVerticalBorehole)
        {
            if(systemVerticalBorehole != null)
            {
                Capacity = systemVerticalBorehole.Capacity;
                DesignPressureDrop = systemVerticalBorehole.DesignPressureDrop;
                Length = systemVerticalBorehole.Length;
                Diameter = systemVerticalBorehole.Diameter;
                GroundConductivity = systemVerticalBorehole.GroundConductivity;
                GroundHeatCapacity = systemVerticalBorehole.GroundHeatCapacity;
                GroundDensity = systemVerticalBorehole.GroundDensity;
                NumberOfBoreholes = systemVerticalBorehole.NumberOfBoreholes;
                GFunction = systemVerticalBorehole.GFunction?.Clone();
                GFunctionReferenceRatio = systemVerticalBorehole.GFunctionReferenceRatio;
                PipeInDiameter = systemVerticalBorehole.PipeInDiameter;
                PipeOutDiameter = systemVerticalBorehole.PipeOutDiameter;
                PipeConductivity = systemVerticalBorehole.PipeConductivity;
                GroutConductivity = systemVerticalBorehole.GroutConductivity;
                GroundTemperatureAve = systemVerticalBorehole.GroundTemperatureAve;
            }
        }

        public SystemVerticalBorehole(System.Guid guid, SystemVerticalBorehole systemVerticalBorehole)
            : base(guid, systemVerticalBorehole)
        {
            if (systemVerticalBorehole != null)
            {
                Capacity = systemVerticalBorehole.Capacity;
                DesignPressureDrop = systemVerticalBorehole.DesignPressureDrop;
                Length = systemVerticalBorehole.Length;
                Diameter = systemVerticalBorehole.Diameter;
                GroundConductivity = systemVerticalBorehole.GroundConductivity;
                GroundHeatCapacity = systemVerticalBorehole.GroundHeatCapacity;
                GroundDensity = systemVerticalBorehole.GroundDensity;
                NumberOfBoreholes = systemVerticalBorehole.NumberOfBoreholes;
                GFunction = systemVerticalBorehole.GFunction?.Clone();
                GFunctionReferenceRatio = systemVerticalBorehole.GFunctionReferenceRatio;
                PipeInDiameter = systemVerticalBorehole.PipeInDiameter;
                PipeOutDiameter = systemVerticalBorehole.PipeOutDiameter;
                PipeConductivity = systemVerticalBorehole.PipeConductivity;
                GroutConductivity = systemVerticalBorehole.GroutConductivity;
                GroundTemperatureAve = systemVerticalBorehole.GroundTemperatureAve;
            }
        }

        public SystemVerticalBorehole(JObject jObject)
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

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("Length"))
            {
                Length = jObject.Value<double>("Length");
            }

            if (jObject.ContainsKey("Diameter"))
            {
                Diameter = jObject.Value<double>("Diameter");
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

            if (jObject.ContainsKey("NumberOfBoreholes"))
            {
                NumberOfBoreholes = jObject.Value<int>("NumberOfBoreholes");
            }

            if (jObject.ContainsKey("GFunction"))
            {
                GFunction = Core.Query.IJSAMObject<GFunction>(jObject.Value<JObject>("GFunction"));
            }

            if (jObject.ContainsKey("GFunctionReferenceRatio"))
            {
                GFunctionReferenceRatio = jObject.Value<double>("GFunctionReferenceRatio");
            }

            if (jObject.ContainsKey("PipeInDiameter"))
            {
                PipeInDiameter = jObject.Value<double>("PipeInDiameter");
            }

            if (jObject.ContainsKey("PipeOutDiameter"))
            {
                PipeOutDiameter = jObject.Value<double>("PipeOutDiameter");
            }

            if (jObject.ContainsKey("PipeConductivity"))
            {
                PipeConductivity = jObject.Value<double>("PipeConductivity");
            }

            if (jObject.ContainsKey("GroutConductivity"))
            {
                GroutConductivity = jObject.Value<double>("GroutConductivity");
            }

            if (jObject.ContainsKey("GroundTemperatureAve"))
            {
                GroundTemperatureAve = jObject.Value<double>("GroundTemperatureAve");
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

            if (!double.IsNaN(Length))
            {
                result.Add("Length", Length);
            }

            if (!double.IsNaN(Diameter))
            {
                result.Add("Diameter", Diameter);
            }

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

            result.Add("NumberOfBoreholes", NumberOfBoreholes);

            if (GFunction != null)
            {
                result.Add("GFunction", GFunction.ToJObject());
            }

            if (!double.IsNaN(GFunctionReferenceRatio))
            {
                result.Add("GFunctionReferenceRatio", GFunctionReferenceRatio);
            }

            if (!double.IsNaN(PipeInDiameter))
            {
                result.Add("PipeInDiameter", PipeInDiameter);
            }

            if (!double.IsNaN(PipeOutDiameter))
            {
                result.Add("PipeOutDiameter", PipeOutDiameter);
            }

            if (!double.IsNaN(PipeConductivity))
            {
                result.Add("PipeConductivity", PipeConductivity);
            }

            if (!double.IsNaN(GroutConductivity))
            {
                result.Add("GroutConductivity", GroutConductivity);
            }

            if (!double.IsNaN(GroundTemperatureAve))
            {
                result.Add("GroundTemperatureAve", GroundTemperatureAve);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemVerticalBorehole(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}