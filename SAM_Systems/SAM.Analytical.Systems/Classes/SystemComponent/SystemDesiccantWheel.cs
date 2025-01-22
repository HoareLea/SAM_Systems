using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class SystemDesiccantWheel : SystemExchanger
    {
        public ModifiableValue Reactivation { get; set; }
        public ModifiableValue MinimumRH { get; set; }
        public ModifiableValue MaximumRH { get; set; }
        public ModifiableValue SensibleHEEfficiency { get; set; }
        public ModifiableValue LatentHEEfficiency { get; set; }
        public SetpointMode HESetpointMethod { get; set; }
        public ModifiableValue HESetpoint { get; set; }
        public ModifiableValue ElectricalLoad { get; set; }


        public SystemDesiccantWheel(string name)
            : base(name)
        {

        }

        public SystemDesiccantWheel(SystemDesiccantWheel systemDesiccantWheel)
            : base(systemDesiccantWheel)
        {
            if(systemDesiccantWheel != null)
            {
                Reactivation = systemDesiccantWheel.Reactivation?.Clone();
                MinimumRH = systemDesiccantWheel.MinimumRH?.Clone();
                MaximumRH = systemDesiccantWheel.MaximumRH?.Clone();
                SensibleHEEfficiency = systemDesiccantWheel.SensibleHEEfficiency?.Clone();
                LatentHEEfficiency = systemDesiccantWheel.LatentHEEfficiency?.Clone();
                HESetpointMethod = systemDesiccantWheel.HESetpointMethod;
                HESetpoint = systemDesiccantWheel.HESetpoint?.Clone();
                ElectricalLoad = systemDesiccantWheel.ElectricalLoad?.Clone();
            }
        }

        public SystemDesiccantWheel(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Reactivation"))
            {
                Reactivation = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Reactivation"));
            }

            if (jObject.ContainsKey("MinimumRH"))
            {
                MinimumRH = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MinimumRH"));
            }

            if (jObject.ContainsKey("MaximumRH"))
            {
                MaximumRH = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("MaximumRH"));
            }

            if (jObject.ContainsKey("SensibleHEEfficiency"))
            {
                SensibleHEEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("SensibleHEEfficiency"));
            }

            if (jObject.ContainsKey("LatentHEEfficiency"))
            {
                LatentHEEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("LatentHEEfficiency"));
            }

            if (jObject.ContainsKey("HESetpointMethod"))
            {
                HESetpointMethod = Core.Query.Enum<SetpointMode>(jObject.Value<string>("HESetpointMethod"));
            }

            if (jObject.ContainsKey("HESetpoint"))
            {
                HESetpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("HESetpoint"));
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ElectricalLoad"));
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

            if (Reactivation != null)
            {
                result.Add("Reactivation", Reactivation.ToJObject());
            }

            if (MinimumRH != null)
            {
                result.Add("MinimumRH", MinimumRH.ToJObject());
            }

            if (MaximumRH != null)
            {
                result.Add("MaximumRH", MaximumRH.ToJObject());
            }

            if (SensibleHEEfficiency != null)
            {
                result.Add("SensibleHEEfficiency", SensibleHEEfficiency.ToJObject());
            }

            if (LatentHEEfficiency != null)
            {
                result.Add("LatentHEEfficiency", LatentHEEfficiency.ToJObject());
            }

            result.Add("HESetpointMethod", HESetpointMethod.ToString());

            if (HESetpoint != null)
            {
                result.Add("HESetpoint", HESetpoint.ToJObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJObject());
            }

            return result;
        }
    }
}
