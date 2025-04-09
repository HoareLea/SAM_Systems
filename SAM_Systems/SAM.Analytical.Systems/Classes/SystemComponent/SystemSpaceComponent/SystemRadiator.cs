using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemRadiator : SystemSpaceComponent
    {
        public ModifiableValue Efficiency { get; set; }
        public ISizableValue Duty { get; set; }

        public string ScheduleName { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Direction.In)
                );
            }
        }

        public SystemRadiator(string name)
            : base(name)
        {
        }

        public SystemRadiator(JObject jObject)
            : base(jObject)
        {

        }

        public SystemRadiator(SystemRadiator systemRadiator)
            : base(systemRadiator)
        {
            if (systemRadiator != null)
            {
                Efficiency = systemRadiator.Efficiency?.Clone();
                Duty = systemRadiator.Duty;
                ScheduleName = systemRadiator.ScheduleName;
            }
        }

        public SystemRadiator(Guid guid, SystemRadiator systemRadiator)
            : base(guid, systemRadiator)
        {
            if (systemRadiator != null)
            {
                Efficiency = systemRadiator.Efficiency?.Clone();
                Duty = systemRadiator.Duty;
                ScheduleName = systemRadiator.ScheduleName;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
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

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemRadiator(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
