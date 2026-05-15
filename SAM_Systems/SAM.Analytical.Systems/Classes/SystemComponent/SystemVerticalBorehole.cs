using System.Text.Json.Nodes;
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

        public SystemVerticalBorehole(JsonObject jObject)
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

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Length"))
            {
                Length = jObject["Length"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Diameter"))
            {
                Diameter = jObject["Diameter"]?.GetValue<double>() ?? default(double);
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

            if (jObject.ContainsKey("NumberOfBoreholes"))
            {
                NumberOfBoreholes = jObject["NumberOfBoreholes"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("GFunction"))
            {
                GFunction = Core.Query.IJSAMObject<GFunction>(jObject["GFunction"] as JsonObject);
            }

            if (jObject.ContainsKey("GFunctionReferenceRatio"))
            {
                GFunctionReferenceRatio = jObject["GFunctionReferenceRatio"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeInDiameter"))
            {
                PipeInDiameter = jObject["PipeInDiameter"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeOutDiameter"))
            {
                PipeOutDiameter = jObject["PipeOutDiameter"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PipeConductivity"))
            {
                PipeConductivity = jObject["PipeConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroutConductivity"))
            {
                GroutConductivity = jObject["GroutConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("GroundTemperatureAve"))
            {
                GroundTemperatureAve = jObject["GroundTemperatureAve"]?.GetValue<double>() ?? default(double);
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
                result.Add("GFunction", GFunction.ToJsonObject());
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