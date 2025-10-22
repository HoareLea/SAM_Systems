using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemLoadComponent : SystemComponent, ILiquidSystemComponent
    {
        public ModifiableValue Value { get; set; }
        public LoadComponentValueType Type { get; set; }
        public double TemperatureDifference { get; set; }
        public double SpecificHeatCapacity { get; set; }
        public double Density { get; set; }


        public SystemLoadComponent(string name)
            : base(name)
        {

        }

        public SystemLoadComponent(SystemLoadComponent systemLoadComponent)
            : base(systemLoadComponent)
        {
            if(systemLoadComponent != null)
            {
                Value = systemLoadComponent.Value?.Clone();
                Type = systemLoadComponent.Type;
                TemperatureDifference = systemLoadComponent.TemperatureDifference;
                SpecificHeatCapacity = systemLoadComponent.SpecificHeatCapacity;
                Density = systemLoadComponent.Density;
            }
        }

        public SystemLoadComponent(Guid guid, SystemLoadComponent systemLoadComponent)
            : base(guid, systemLoadComponent)
        {
            if (systemLoadComponent != null)
            {
                Value = systemLoadComponent.Value?.Clone();
                Type = systemLoadComponent.Type;
                TemperatureDifference = systemLoadComponent.TemperatureDifference;
                SpecificHeatCapacity = systemLoadComponent.SpecificHeatCapacity;
                Density = systemLoadComponent.Density;
            }
        }

        public SystemLoadComponent(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    //Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("Value"))
            {
                Value = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Value"));
            }

            if (jObject.ContainsKey("Type"))
            {
                Type = Core.Query.Enum<LoadComponentValueType>(jObject.Value<string>("Type"));
            }

            if (jObject.ContainsKey("TemperatureDifference"))
            {
                TemperatureDifference = jObject.Value<double>("TemperatureDifference");
            }

            if (jObject.ContainsKey("SpecificHeatCapacity"))
            {
                SpecificHeatCapacity = jObject.Value<double>("SpecificHeatCapacity");
            }

            if (jObject.ContainsKey("Density"))
            {
                Density = jObject.Value<double>("Density");
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
            
            if (Value != null)
            {
                result.Add("Value", Value.ToJObject());
            }

            if (Value != null)
            {
                result.Add("Type", Type.ToString());
            }

            if (!double.IsNaN(TemperatureDifference))
            {
                result.Add("TemperatureDifference", TemperatureDifference);
            }

            if (!double.IsNaN(SpecificHeatCapacity))
            {
                result.Add("SpecificHeatCapacity", SpecificHeatCapacity);
            }

            if (!double.IsNaN(Density))
            {
                result.Add("Density", Density);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLoadComponent(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}