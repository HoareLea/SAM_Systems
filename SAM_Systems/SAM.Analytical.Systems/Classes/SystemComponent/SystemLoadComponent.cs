using System.Text.Json.Nodes;
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

        public SystemLoadComponent(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Value"))
            {
                Value = Core.Query.IJSAMObject<ModifiableValue>(jObject["Value"] as JsonObject);
            }

            if (jObject.ContainsKey("Type"))
            {
                Type = Core.Query.Enum<LoadComponentValueType>(jObject["Type"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("TemperatureDifference"))
            {
                TemperatureDifference = jObject["TemperatureDifference"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SpecificHeatCapacity"))
            {
                SpecificHeatCapacity = jObject["SpecificHeatCapacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Density"))
            {
                Density = jObject["Density"]?.GetValue<double>() ?? default(double);
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
            
            if (Value != null)
            {
                result.Add("Value", Value.ToJsonObject());
            }

            if(Type != LoadComponentValueType.Undefined)
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