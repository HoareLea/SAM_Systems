using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDXCoil : SystemComponent
    {
        public ModifiableValue CoolingSetpoint { get; set; }
        public ModifiableValue HeatingSetpoint { get; set; }

        public ModifiableValue MinOffcoilTemperature { get; set; }
        public ModifiableValue MaxOffcoilTemperature { get; set; }

        public ModifiableValue BypassFactor { get; set; }

        public ISizableValue CoolingDuty { get; set; }
        public ISizableValue HeatingDuty { get; set; }

        public string ScheduleName { get; set; }

        public SystemDXCoil(string name)
            : base(name)
        {

        }

        public SystemDXCoil(SystemDXCoil systemDXCoil)
            : base(systemDXCoil)
        {
            if (systemDXCoil != null)
            {
                CoolingSetpoint = systemDXCoil.CoolingSetpoint.Clone();
                HeatingSetpoint = systemDXCoil.HeatingSetpoint.Clone();
                MinOffcoilTemperature = systemDXCoil.MinOffcoilTemperature.Clone();
                MaxOffcoilTemperature = systemDXCoil.MaxOffcoilTemperature.Clone();
                BypassFactor = systemDXCoil.BypassFactor.Clone();
                CoolingDuty = systemDXCoil.CoolingDuty.Clone();
                HeatingDuty = systemDXCoil.HeatingDuty.Clone();
                ScheduleName = systemDXCoil.ScheduleName;
            }
        }

        public SystemDXCoil(JObject jObject)
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
                    //Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.In, 2),
                    //Core.Systems.Create.SystemConnector<RefrigerantSystem>(Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>(),
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

            if (jObject.ContainsKey("CoolingSetpoint"))
            {
                CoolingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CoolingSetpoint"));
            }

            if (jObject.ContainsKey("HeatingSetpoint"))
            {
                HeatingSetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HeatingSetpoint"));
            }

            if (jObject.ContainsKey("MinOffcoilTemperature"))
            {
                MinOffcoilTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MinOffcoilTemperature"));
            }

            if (jObject.ContainsKey("MaxOffcoilTemperature"))
            {
                MaxOffcoilTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MaxOffcoilTemperature"));
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("BypassFactor"));
            }

            if (jObject.ContainsKey("CoolingDuty"))
            {
                CoolingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("CoolingDuty"));
            }

            if (jObject.ContainsKey("HeatingDuty"))
            {
                HeatingDuty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("HeatingDuty"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (CoolingSetpoint != null)
            {
                result.Add("CoolingSetpoint", CoolingSetpoint.ToJObject());
            }

            if (HeatingSetpoint != null)
            {
                result.Add("HeatingSetpoint", HeatingSetpoint.ToJObject());
            }

            if (MinOffcoilTemperature != null)
            {
                result.Add("MinOffcoilTemperature", MinOffcoilTemperature.ToJObject());
            }

            if (MaxOffcoilTemperature != null)
            {
                result.Add("MaxOffcoilTemperature", MaxOffcoilTemperature.ToJObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJObject());
            }

            if (CoolingDuty != null)
            {
                result.Add("CoolingDuty", CoolingDuty.ToJObject());
            }

            if (HeatingDuty != null)
            {
                result.Add("HeatingDuty", HeatingDuty.ToJObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}
