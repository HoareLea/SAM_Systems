using Newtonsoft.Json.Linq;
using SAM.Analytical.Systems.Interfaces;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemDesiccantWheel : SystemComponent, ISystemExchanger
    {
        public ModifiableValue SensibleEfficiency { get; set; }
        public ModifiableValue Reactivation { get; set; }
        public ModifiableValue MinimumRH { get; set; }
        public ModifiableValue MaximumRH { get; set; }
        public ModifiableValue SensibleHEEfficiency { get; set; }
        public ModifiableValue LatentHEEfficiency { get; set; }
        public SetpointMode HESetpointMethod { get; set; }
        public ModifiableValue HESetpoint { get; set; }
        public ModifiableValue ElectricalLoad { get; set; }

        public string ScheduleName { get; set; }


        public SystemDesiccantWheel(string name)
            : base(name)
        {

        }

        public SystemDesiccantWheel(SystemDesiccantWheel systemDesiccantWheel)
            : base(systemDesiccantWheel)
        {
            if(systemDesiccantWheel != null)
            {
                SensibleEfficiency = systemDesiccantWheel.SensibleEfficiency?.Clone();
                Reactivation = systemDesiccantWheel.Reactivation?.Clone();
                MinimumRH = systemDesiccantWheel.MinimumRH?.Clone();
                MaximumRH = systemDesiccantWheel.MaximumRH?.Clone();
                SensibleHEEfficiency = systemDesiccantWheel.SensibleHEEfficiency?.Clone();
                LatentHEEfficiency = systemDesiccantWheel.LatentHEEfficiency?.Clone();
                HESetpointMethod = systemDesiccantWheel.HESetpointMethod;
                HESetpoint = systemDesiccantWheel.HESetpoint?.Clone();
                ElectricalLoad = systemDesiccantWheel.ElectricalLoad?.Clone();
                ScheduleName = systemDesiccantWheel.ScheduleName;
            }
        }

        public SystemDesiccantWheel(JObject jObject)
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

            if (jObject.ContainsKey("SensibleEfficiency"))
            {
                SensibleEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("SensibleEfficiency"));
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

            if (SensibleEfficiency != null)
            {
                result.Add("SensibleEfficiency", SensibleEfficiency.ToJObject());
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

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }
    }
}
