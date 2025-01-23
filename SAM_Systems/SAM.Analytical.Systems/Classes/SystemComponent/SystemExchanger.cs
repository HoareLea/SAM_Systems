using Newtonsoft.Json.Linq;
using SAM.Analytical.Systems.Interfaces;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    /// <summary>
    /// Heat Recovery (Air Side)
    /// </summary>
    public class SystemExchanger : SystemComponent, ISystemExchanger
    {
        public ExchangerCalculationMethod ExchangerCalculationMethod { get; set; }
        public ExchangerType ExchangerType { get; set; }
        public ModifiableValue SensibleEfficiency { get; set; }
        public double HeatTransferSurfaceArea { get; set; }
        public double HeatTransferCoefficient { get; set; }
        public ExchangerLatentType ExchangerLatentType { get; set; }
        public ModifiableValue LatentEfficiency { get; set; }
        public SetpointMode SetpointMode { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue ElectricalLoad { get; set; }
        public SizableValue Duty { get; set; }
        public ModifiableValue BypassFactor { get; set; }

        public SystemExchanger(string name)
            : base(name)
        {

        }

        public SystemExchanger(SystemExchanger systemExchanger)
            : base(systemExchanger)
        {
            if(systemExchanger != null)
            {
                ExchangerCalculationMethod = systemExchanger.ExchangerCalculationMethod;
                ExchangerType = systemExchanger.ExchangerType;
                SensibleEfficiency = systemExchanger.SensibleEfficiency?.Clone();
                HeatTransferSurfaceArea = systemExchanger.HeatTransferSurfaceArea;
                HeatTransferCoefficient = systemExchanger.HeatTransferCoefficient;
                ExchangerLatentType = systemExchanger.ExchangerLatentType;
                LatentEfficiency = systemExchanger.LatentEfficiency?.Clone();
                SetpointMode = systemExchanger.SetpointMode;
                Setpoint = systemExchanger.Setpoint?.Clone();
                ElectricalLoad = systemExchanger.ElectricalLoad?.Clone();
                Duty = systemExchanger.Duty?.Clone();
                BypassFactor = systemExchanger.BypassFactor?.Clone();
            }
        }

        public SystemExchanger(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<AirSystem>(Direction.Out, 2),
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

            if (jObject.ContainsKey("ExchangerCalculationMethod"))
            {
                ExchangerCalculationMethod = Core.Query.Enum<ExchangerCalculationMethod>(jObject.Value<string>("ExchangerCalculationMethod"));
            }

            if (jObject.ContainsKey("ExchangerType"))
            {
                ExchangerType = Core.Query.Enum<ExchangerType>(jObject.Value<string>("ExchangerType"));
            }

            if (jObject.ContainsKey("SensibleEfficiency"))
            {
                SensibleEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("SensibleEfficiency"));
            }

            if (jObject.ContainsKey("HeatTransferSurfaceArea"))
            {
                HeatTransferSurfaceArea = jObject.Value<double>("HeatTransferSurfaceArea");
            }

            if (jObject.ContainsKey("ExchangerLatentType"))
            {
                ExchangerLatentType = Core.Query.Enum<ExchangerLatentType>(jObject.Value<string>("ExchangerLatentType"));
            }

            if (jObject.ContainsKey("LatentEfficiency"))
            {
                LatentEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("LatentEfficiency"));
            }

            if (jObject.ContainsKey("SetpointMode"))
            {
                SetpointMode = Core.Query.Enum<SetpointMode>(jObject.Value<string>("SetpointMode"));
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ElectricalLoad"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("BypassFactor"));
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

            result.Add("ExchangerCalculationMethod", ExchangerCalculationMethod.ToString());

            result.Add("ExchangerType", ExchangerType.ToString());

            if (SensibleEfficiency != null)
            {
                result.Add("SensibleEfficiency", SensibleEfficiency.ToJObject());
            }

            if (double.IsNaN(HeatTransferSurfaceArea))
            {
                result.Add("HeatTransferSurfaceArea", HeatTransferSurfaceArea);
            }

            if (double.IsNaN(HeatTransferCoefficient))
            {
                result.Add("HeatTransferCoefficient", HeatTransferCoefficient);
            }

            result.Add("ExchangerLatentType", ExchangerLatentType.ToString());

            if (LatentEfficiency != null)
            {
                result.Add("LatentEfficiency", LatentEfficiency.ToJObject());
            }

            result.Add("SetpointMode", SetpointMode.ToString());

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJObject());
            }

            return result;
        }
    }
}
