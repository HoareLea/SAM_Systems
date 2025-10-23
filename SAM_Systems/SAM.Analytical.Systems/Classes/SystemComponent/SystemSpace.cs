using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSpace : SystemComponent, ISystemSpace, IAirSystemComponent
    {
        private double area;
        private double volume;

        public ModifiableValue TemperatureSetpoint { get; set; }
        public ModifiableValue RelativeHumiditySetpoint { get; set; }
        public ModifiableValue PollutantSetpoint { get; set; }
        public bool DisplacementVentilation { get; set; }
        public bool ModelInterzoneFlow { get; set; }
        public bool ModelVentilationFlow { get; set; }
        public DesignConditionSizedFlowValue FlowRate { get; set; }
        public DesignConditionSizedFlowValue FreshAir { get; set; }

        public double MinimumDesignFlowFraction { get; set; }

        public SystemSpace(string name, double area, double volume, ModifiableValue temperatureSetpoint, ModifiableValue relativeHumiditySetpoint, ModifiableValue pollutantSetpoint, bool displacementVentilation, bool modelInterzoneFlow, bool modelVentilationFlow, DesignConditionSizedFlowValue flowRate, DesignConditionSizedFlowValue freshAir, double minimumDesignFlowFraction)
            : base(name)
        {
            this.area = area;
            this.volume = volume;
            TemperatureSetpoint = temperatureSetpoint?.Clone();
            RelativeHumiditySetpoint = relativeHumiditySetpoint?.Clone();
            PollutantSetpoint = pollutantSetpoint?.Clone();
            DisplacementVentilation = displacementVentilation;
            ModelInterzoneFlow = modelInterzoneFlow;
            ModelVentilationFlow = modelVentilationFlow;
            FlowRate = flowRate?.Clone();
            FreshAir = freshAir?.Clone();
            MinimumDesignFlowFraction = minimumDesignFlowFraction;
        }

        public SystemSpace(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemSpace(SystemSpace systemSpace)
            : base(systemSpace)
        {
            if (systemSpace != null)
            {
                area = systemSpace.area;
                volume = systemSpace.volume;

                TemperatureSetpoint = systemSpace.TemperatureSetpoint?.Clone();
                RelativeHumiditySetpoint = systemSpace.RelativeHumiditySetpoint?.Clone();
                PollutantSetpoint = systemSpace.PollutantSetpoint?.Clone();
                DisplacementVentilation = systemSpace.DisplacementVentilation;
                ModelInterzoneFlow = systemSpace.ModelInterzoneFlow;
                ModelVentilationFlow = systemSpace.ModelVentilationFlow;
                FlowRate = systemSpace.FlowRate;
                FreshAir = systemSpace.FreshAir;
                MinimumDesignFlowFraction = systemSpace.MinimumDesignFlowFraction;
            }
        }

        public SystemSpace(System.Guid guid, SystemSpace systemSpace)
            : base(guid, systemSpace)
        {
            if (systemSpace != null)
            {
                area = systemSpace.area;
                volume = systemSpace.volume;

                TemperatureSetpoint = systemSpace.TemperatureSetpoint?.Clone();
                RelativeHumiditySetpoint = systemSpace.RelativeHumiditySetpoint?.Clone();
                PollutantSetpoint = systemSpace.PollutantSetpoint?.Clone();
                DisplacementVentilation = systemSpace.DisplacementVentilation;
                ModelInterzoneFlow = systemSpace.ModelInterzoneFlow;
                ModelVentilationFlow = systemSpace.ModelVentilationFlow;
                FlowRate = systemSpace.FlowRate;
                FreshAir = systemSpace.FreshAir;
                MinimumDesignFlowFraction = systemSpace.MinimumDesignFlowFraction;
            }
        }

        public double Area
        {
            get
            {
                return area;
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }
        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Direction.Out)
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

            if (jObject.ContainsKey("Area"))
            {
                area = jObject.Value<double>("Area");
            }

            if (jObject.ContainsKey("Volume"))
            {
                volume = jObject.Value<double>("Volume");
            }

            if (jObject.ContainsKey("TemperatureSetpoint"))
            {
                TemperatureSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("TemperatureSetpoint"));
            }

            if (jObject.ContainsKey("RelativeHumiditySetpoint"))
            {
                RelativeHumiditySetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("RelativeHumiditySetpoint"));
            }

            if (jObject.ContainsKey("PollutantSetpoint"))
            {
                PollutantSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PollutantSetpoint"));
            }

            if (jObject.ContainsKey("DisplacementVentilation"))
            {
                DisplacementVentilation = jObject.Value<bool>("DisplacementVentilation");
            }

            if (jObject.ContainsKey("ModelInterzoneFlow"))
            {
                ModelInterzoneFlow = jObject.Value<bool>("ModelInterzoneFlow");
            }

            if (jObject.ContainsKey("ModelVentilationFlow"))
            {
                ModelVentilationFlow = jObject.Value<bool>("ModelVentilationFlow");
            }

            if (jObject.ContainsKey("FlowRate"))
            {
                FlowRate = Core.Query.IJSAMObject<DesignConditionSizedFlowValue>(jObject.Value<JObject>("FlowRate"));
            }

            if (jObject.ContainsKey("FreshAir"))
            {
                FreshAir = Core.Query.IJSAMObject<DesignConditionSizedFlowValue>(jObject.Value<JObject>("FreshAir"));
            }

            if (jObject.ContainsKey("MinimumDesignFlowFraction"))
            {
                MinimumDesignFlowFraction = jObject.Value<double>("MinimumDesignFlowFraction");
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (!double.IsNaN(area))
            {
                result.Add("Area", area);
            }

            if (!double.IsNaN(volume))
            {
                result.Add("Volume", volume);
            }

            if(TemperatureSetpoint != null)
            {
                result.Add("TemperatureSetpoint", TemperatureSetpoint.ToJObject());
            }

            if (RelativeHumiditySetpoint != null)
            {
                result.Add("RelativeHumiditySetpoint", RelativeHumiditySetpoint.ToJObject());
            }

            if (PollutantSetpoint != null)
            {
                result.Add("PollutantSetpoint", PollutantSetpoint.ToJObject());
            }

            result.Add("DisplacementVentilation", DisplacementVentilation);

            result.Add("ModelVentilationFlow", ModelVentilationFlow);

            result.Add("ModelInterzoneFlow", ModelInterzoneFlow);

            if (FlowRate != null)
            {
                result.Add("FlowRate", FlowRate.ToJObject());
            }

            if (FreshAir != null)
            {
                result.Add("FreshAir", FreshAir.ToJObject());
            }

            if (!double.IsNaN(MinimumDesignFlowFraction))
            {
                result.Add("MinimumDesignFlowFraction", MinimumDesignFlowFraction);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSpace(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
