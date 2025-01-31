using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemCoolingCoil: SystemComponent,IAirSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue BypassFactor { get; set; }
        public ISizableValue Duty { get; set; }
        public ModifiableValue MinimumOffcoil { get; set; }

        public string ScheduleName { get; set; }

        public SystemCoolingCoil(string name)
            : base(name)
        {

        }

        public SystemCoolingCoil(SystemCoolingCoil systemCoolingCoil)
            : base(systemCoolingCoil)
        {
            if(systemCoolingCoil != null)
            {
                Setpoint = systemCoolingCoil.Setpoint?.Clone();
                BypassFactor = systemCoolingCoil.BypassFactor?.Clone();
                Duty = systemCoolingCoil.Duty?.Clone();
                MinimumOffcoil = systemCoolingCoil.MinimumOffcoil?.Clone();
                ScheduleName = systemCoolingCoil.ScheduleName;
            }
        }

        public SystemCoolingCoil(JObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("BypassFactor"))
            {
                BypassFactor = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("BypassFactor"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("MinimumOffcoil"))
            {
                MinimumOffcoil = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MinimumOffcoil"));
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
            if(result == null)
            {
                return result;
            }


            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (BypassFactor != null)
            {
                result.Add("BypassFactor", BypassFactor.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (MinimumOffcoil != null)
            {
                result.Add("MinimumOffcoil", MinimumOffcoil.ToJObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}
